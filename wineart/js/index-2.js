// JavaScript Document

$(document).ready(function () {
	$('#logo').css({
			'position': 'absolute',
			'bottom': '100px',
			'right': '50px'
		});
		if($(window).height()<=840)
				$('.content_wrapper').css({'height' : '650px'});			
			else
				$('.content_wrapper').css({'height' : '770px'});				

		
		jQuery(window).resize(function(){
			$('#logo').css({
				'position': 'absolute',
				'bottom': '100px',
				'right': '50px'
			});
			if($(window).height()<=840)
				$('.content_wrapper').css({'height' : '650px'});			
			else
				$('.content_wrapper').css({'height' : '770px'});			
		});

});