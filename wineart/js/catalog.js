// JavaScript Document

var CatalogActive = false;
var ShoppingCartActive = false;
var image = 3;
var fullCatalogo = "";

/* Función principal hasta que la página esté cargada */
$(document).ready(function () {
    $('.wine_list').draggable();
		$('.shopping_cart').draggable();
		fullCatalogo=LoadCatalog();
		LlenadoDeFiltroCombo("ddlproducto","Producto");
		LlenadoDeFiltroCombo("ddldescripcion","Descripcion");
		LlenadoDeFiltroCombo("ddlpais","Origen");
		DesplegarCatalogo();
		
		/* Maneja el ocultamiento y despliegue de la ventana del catálogo */
		function ShowHideCatalog(){
			if(!CatalogActive){					
					$('.wine_list').show();
					CatalogActive = true;
				} else {
					$('.wine_list').hide();
					CatalogActive = false;
				}
		}
		
		/* Maneja el ocultamiento y despliegue de la ventana del carrito de compras */		
		function ShowHideShoppingCart(){
			if(!ShoppingCartActive){					
					$('.shopping_cart').show();
					ShoppingCartActive = true;
				} else {
					$('.shopping_cart').hide();
					ShoppingCartActive = false;
				}
		}

		/* Maneja la botonera en el menú para activar catálogo y carrito y los botones de cierre de las ventanas */
		$('#btnCatalog').click(ShowHideCatalog);
		$('#btnCerrarCatalogo').click(ShowHideCatalog);				
		$('#btnShoppingCart').click(ShowHideShoppingCart);
		$('#btnCerrarCarrito').click(ShowHideShoppingCart);				
		
		/* Asigna el tamaño original del block de despliegue blanco.*/
		$('#descrHolder').css({  
			'height': ($(window).height()-308)+'px'
		});		
		
		/* Reasigna el tamaño del block de despliegue una vez que la pantalla se redimensiona */
		$(window).resize(function(){
			$('#descrHolder').css({  
				'height': ($(window).height()-308)+'px'
			});
		});					
		
		/* Esta sección maneja los Combos o DropDownList que corresponden a los filtros */
		$("#ddlproducto").on("change",function(){
			DesplegarCatalogo();
		});
		$("#ddldescripcion").on("change",function(){
			DesplegarCatalogo();
		});
		$("#ddlpais").on("change",function(){
			DesplegarCatalogo();
		});		
		/* Fin de sección de combos */
		
		$(document).delegate(".AddSKButton","click",function(){
			var amount = +$(this).closest('tr').find(".SKCantidad").text();
			amount++;
			$(this).closest('tr').find(".SKCantidad").text(amount);
		});
		
		$(document).delegate(".RemoveSKButton","click",function(){
			var amount = +$(this).closest('tr').find(".SKCantidad").text();
			amount--;
			if(amount<=0)
				$(this).closest('tr').remove();
			else{
				$(this).closest('tr').find(".SKCantidad").text(amount);				
			}				
		});		
		
		$(document).delegate(".EraseLineSKButton","click",function(e){
			$(this).closest('tr').remove();
		});			
		
		
		
		
		$(document).delegate(".BotonAgregar", "click",function(){
			/*scSubTotal
				scTrasporte
				scDescuento
				scTotal*/
			
			var index = +$(this).attr('product_index');
			if($("#spnCantidad"+index).val()!="" && $("#spnCantidad"+index).val()!=null && $("#spnCantidad"+index).val()!=undefined && $("#spnCantidad"+index).val()>0){
				var precio = (+fullCatalogo[index].PrecioUnitario.replace(",",""))*(+$("#spnCantidad"+index).val());
				var descuento = 0;
				var tmpDesc = +$("#scDescuento").val();
				if(+$("#spnCantidad"+index).val()>=6){
					var precioDescuento = (+fullCatalogo[index].PrecioCaja.replace(",",""))*(+$("#spnCantidad"+index).val());
					descuento = precio - precioDescuento;
					tmpDesc = tmpDesc+descuento;
					$("#scDescuento").text(tmpDesc);					
				}
				var total = precio-descuento;
				if(isNaN(+$("scSubTotal").val()))
					var tmpTotal = total;	
				else
					var tmpTotal = (+$("scSubTotal").val())+total;
				var tmpTransporte = 5000;
				
				
				var sccSubTotal = $("#scSubTotal").val();
				if(isNaN(sccSubTotal))
					sccSubTotal=0;
				sccSubTotal = sccSubTotal;
				
				$("#scSubTotal").text(sccSubTotal + total);
				$("#scTransporte").text(tmpTransporte);
				$("#scTotal").text(tmpTotal+tmpTransporte);
				$('.sc_content').append(		
					'<tr sk_index='+index+'>'+
					'<td style="min-width:3px;color:yellow;"><a class="AddSKButton">+</a></td>' +
					'<td style="min-width:10px;padding-left:1px;" class="SKCantidad">'+$("#spnCantidad"+index).val()+'</td>' +
					'<td style="min-width:3px;color:yellow;"><a class="RemoveSKButton">-</a></td>' +
					'<td style="min-width:175px;text-align:left;padding-left:10px;">'+fullCatalogo[index].Descripcion+'</td>' +
					'<td style="min-width:30px;padding-left:5px;text-align:right;" class="SKPrecio">'+(precio+"").replace(/\B(?=(\d{3})+(?!\d))/g, ",")+'</td>' +
					'<td style="min-width:30px;padding-left:5px;text-align:right;" class="SKDescuentoLinea">'+(descuento+"").replace(/\B(?=(\d{3})+(?!\d))/g, ",")+'</td>' +
					'<td style="min-width:30px;padding-left:5px;text-align:right;" class="SKTotalLinea">'+(total+"").replace(/\B(?=(\d{3})+(?!\d))/g, ",")+'</td>' +					
					'<td style="min-width:3px;padding-left:5px;color:yellow;"><a class="EraseLineSKButton">X</a></td>' +
					'</tr>'
				);			
			}
		});						
		
		/**** JavaScript Functions section ***/
		
		/* Maneja el despliegue de los datos en el catálogo */
		function LoadCatalog(){		// Esta es la consulta ajax al catálogo en formato json
			var catalogo="";
			$.ajax({
			  dataType: "json",
			  url: "js/catalogo.js",
			  contentType : "application/json; charset=iso-8859-4",
				async: false,
		  	success: function(data){
					catalogo = data;
				}
			});
			return catalogo;
		}
		
		/* Esta función maneja el filtro del tipo de producto o categoría */
		function LlenadoDeFiltroCombo(pNombreCombo, pPropiedad){			
			var list = "";
			$("#"+pNombreCombo).append("<option value="+-1+">Todos</option>");			
			var arr = new Array();
			$.each(fullCatalogo, function(index, element){
				if ($.inArray(element[pPropiedad], arr) === -1) {			
					arr.push(element[pPropiedad]);		
				}
			});					
			arr.sort();			
			
			$.each(arr, function(key, value){
				if($("#"+pNombreCombo+" option[value='" + value + "']").val() === undefined) {
					$("#"+pNombreCombo).append("<option value='"+value+"'>"+value+"</option>");
				}
			});		
		}	/* Fin de función de producto o categoría */			
					
		/* Manejo del slideshow de la página principal*/
		setInterval(function () {		
			if(image>=15)
				image = 4;
			else
				image++;    
			$('#topImg').fadeOut("slow", function() {
     	  $('#topImg').attr('src',"images/wa/"+image+".jpg");
	    }).fadeIn("slow");
			$('#bottomImg').attr('src',"images/wa/"+image+".jpg");		
			$('#botomImg').fadeOut("fast", function() {        
		    }).fadeIn("fast");			
		}, 4000);				
		
		/* Esta función recorre el catálogo y lo despliega en la ventana */
		function DesplegarCatalogo(){	
			$("#catalog_detail").children().remove();
			$("#catalog_detail").append("<tr class='tableizer-firstrow'></tr>");
			$.each(fullCatalogo, function(index, element){		
				if((($('#ddlproducto option:selected').text()==='Todos') || 
 	 	    	  ($('#ddlproducto option:selected').text()===element.Producto)) &&
		  	   (($('#ddldescripcion option:selected').text()==='Todos') || 
	 			    ($('#ddldescripcion option:selected').text()===element.Descripcion)) &&
		  	   (($('#ddlpais option:selected').text()==='Todos') || 
				    ($('#ddlpais option:selected').text()===element.Origen))){						
	
						$('#catalog_detail').append(		
							'<tr>'+
							'<td style="min-width:95px;padding-left:10px;">'+element.Producto+'</td>'+
							'<td style="min-width:110px;padding-left:0px;">'+element.Descripcion+'</td>'+
							'<td style="min-width:80px;padding-left:10px;">'+element.Origen+'</td>'+						
							'<td style="min-width:80px;padding-left:0px;">'+element.PrecioUnitario+'</td>'+		
							'<td style="min-width:40px;padding-left:15px;"><input type="number" id="spnCantidad'+index+'" min="0" max="99" style="width:40px;" value="1"></td>'+								
							'<td><input type="button" id="btnAdd'+index+'" product_index='+index+' value="Comprar" class="BotonAgregar"></td>'+
							'</tr>'
						);
					}
			});
		}
		/* Fin de sección de despliegue de catálogo */
});