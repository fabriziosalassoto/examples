// JavaScript Document

$('#logo').css({
			'position': 'absolute',
			'top': jQuery(window).height()-$('#logo').height()-180+'px',
			'left': ($(window).width()-280-45)+'px'
		});		
		
		jQuery(window).resize(function(){
			$('#logo').css({
				'position': 'absolute',
				'top': jQuery(window).height()-$('#logo').height()-180+'px',
				'left': ($(window).width()-280-45)+'px'
			});
			$('#descrHolder').css({  
				'height': ($(window).height()-308)+'px'
			});
		});