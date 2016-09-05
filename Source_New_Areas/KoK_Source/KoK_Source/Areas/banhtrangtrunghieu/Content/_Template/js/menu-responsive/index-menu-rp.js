jQuery.noConflict()(function($) {
   
    $('nav#menu').mmenu({
     extensions : [ 'effect-slide-menu', 'pageshadow' ],
     searchfield : false,
     counters : false,
     navbar   : {
      title  : 'MENU'
     },
     navbars  : [
       {
       position : 'top',
       content  : [
        'prev',
        'title',
        'close'
       ]
      }, {
       position : 'bottom',
       content  : [
       ''
       ]
      }
     ]
    });
   });