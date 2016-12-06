;(function($) {
	// DOM ready
	$(function() {
		
		// Append the mobile icon nav

		$('.m_nav').append($('<div class="nav-mobile" ><a href="/" style="padding: 0px;padding:0px 0 0 43px;font-size: 22px;line-height: 56px;font-weight:0.4px;" class=" filter_img" alt="" style="margin-top:-2px;margin-left:-20px;" title="rainbrace">rainbrace</a><div><span></span></div></div>'));
		
		// Add a <span> to every .nav-item that has a <ul> inside
		$('.nav-item').has('ul').prepend('<span class="nav-click"><i class="nav-arrow"></i></span>');
		
		// Click to reveal the nav
		$('.nav-mobile div').click(function(){
			$('.nav-mobile div').toggleClass('active');
			$('.nav-list-new').slideToggle(300);
		});
	
		// Dynamic binding to on 'click'
		$('.nav-list-new').on('click', '.nav-click', function(){
		
			// Toggle the nested nav
			$(this).siblings('.nav-submenu').slideToggle(300);
			
			// Toggle the arrow using CSS3 transforms
			$(this).children('.nav-arrow').toggleClass('nav-rotate');
			
		});
	    
	});
	
})(jQuery);