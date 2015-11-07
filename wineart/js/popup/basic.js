/*
 * SimpleModal Basic Modal Dialog
 * http://simplemodal.com
 *
 * Copyright (c) 2013 Eric Martin - http://ericmmartin.com
 *
 * Licensed under the MIT license:
 *   http://www.opensource.org/licenses/mit-license.php
 */

$(function() {
	// Load dialog on page load
	//$('#basic-modal-content').modal();

	// Load dialog on click				
	$('.photo_galeria').click(function (e) {
		$('#big_picture').attr({'src': 'images/galeria/display/'+$(this).attr('dt_id')+'.JPG'});
		$('#big_picture').load(function() {
    	$('#basic-modal-content').modal();
		});
		
		return false;
	});
});