// JavaScript Document

// JavaScript Document

$(document).ready(function () {
	$('#logo').css({
			'position': 'absolute',
			'bottom': '350px',
			'right': '50px'
		});
		if($(window).height()<=680)
			$('.grid_9').css({'margin-bottom' : '50px'});			
		else
			$('.grid_9').css({'margin-bottom' : '150px'});			
	
		
		jQuery(window).resize(function(){
			$('#logo').css({
				'position': 'absolute',
				'bottom': '300px',
				'right': '50px'
			});
			if($(window).height()<=840)
				$('.grid_9').css({'margin-bottom' : '50px'});			
			else
				$('.grid_9').css({'margin-bottom' : '150px'});			
		});
});