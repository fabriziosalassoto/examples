// JavaScript Document

$(document).ready(function () {
	$('#logo').css({
			'position': 'absolute',
			'bottom': '200px',
			'right': '50px'
		});
		
		jQuery(window).resize(function(){
			$('#logo').css({
				'position': 'absolute',
				'bottom': '150px',
				'right': '50px'
			});
		});
});