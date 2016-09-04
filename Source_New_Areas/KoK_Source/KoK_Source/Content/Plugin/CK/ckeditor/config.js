/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	 config.language = 'vi';
	 config.uiColor = '#585858';
     //config.extraPlugins = 'oembed';
    //config.extraPlugins = 'dialog';
    //config.extraPlugins = 'videodetector';
	 config.extraPlugins = 'youtube';
	 config.removeButtons = 'About,Flash,Print';
};
