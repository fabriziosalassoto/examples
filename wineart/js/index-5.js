// JavaScript Document

$(document).ready(function () {
	$('#logo').css({
			'position': 'absolute',
			'bottom': '250px',
			'right': '50px'
		});
		if($(window).height()<=840)
				$('.grid_9').css({'margin-bottom' : '50px'});			
			else
				$('.grid_9').css({'margin-bottom' : '170px'});
		
		jQuery(window).resize(function(){
			$('#logo').css({
				'position': 'absolute',
				'bottom': '200px',
				'right': '50px'
			});
			if($(window).height()<=840)
				$('.grid_9').css({'margin-bottom' : '50px'});			
			else
				$('.grid_9').css({'margin-bottom' : '170px'});
		});
});