// JavaScript Document
/**
 *  Responsive index new banner add by zsx
 */
/* 
(function($, f) {
	//  If there's no jQuery, Unslider can't work, so kill the operation.
	if(!$) return f;
	
	var Unslider = function() {
		//  Set up our elements
		this.el = f;
		this.items = f;
		
		//  Dimensions
		this.sizes = [];
		this.max = [0,0];
		
		//  Current inded
		this.current = 0;
		
		//  Start/stop timer
		this.interval = f;
				
		//  Set some options
		this.opts = {
			speed: 500,
			delay: 3000, // f for no autoplay
			complete: f, // when a slide's finished
			keys: !f, // keyboard shortcuts - disable if it breaks things
			dots: f, // display ••••o• pagination
			fluid: f // is it a percentage width?,
		};
		
		//  Create a deep clone for methods where context changes
		var _ = this;

		this.init = function(el, opts) {
			this.el = el;
			this.ul = el.children('ul');
			this.max = [el.outerWidth(), el.outerHeight()];			
			this.items = this.ul.children('li').each(this.calculate);
			
			//  Check whether we're passing any options in to Unslider
			this.opts = $.extend(this.opts, opts);
			
			//  Set up the Unslider
			this.setup();
			
			return this;
		};
		
		//  Get the width for an element
		//  Pass a jQuery element as the context with .call(), and the index as a parameter: Unslider.calculate.call($('li:first'), 0)
		this.calculate = function(index) {
			var me = $(this),
				width = me.outerWidth(), height = me.outerHeight();
			
			//  Add it to the sizes list
			_.sizes[index] = [width, height];
			
			//  Set the max values
			if(width > _.max[0]) _.max[0] = width;
			if(height > _.max[1]) _.max[1] = height;
		};
		
		//  Work out what methods need calling
		this.setup = function() {
			//  Set the main element
			this.el.css({
				overflow: 'hidden',
				width: _.max[0],
				height: this.items.first().outerHeight()
			});
			
			//  Set the relative widths
			this.ul.css({width: (this.items.length * 100) + '%', position: 'relative'});
			this.items.css('width', (100 / this.items.length) + '%');
			
			if(this.opts.delay !== f) {
				this.start();
				this.el.hover(this.stop, this.start);
			}
			
			//  Custom keyboard support
			this.opts.keys && $(document).keydown(this.keys);
			
			//  Dot pagination
			this.opts.dots && this.dots();
			
			//  Little patch for fluid-width sliders. Screw those guys.
			if(this.opts.fluid) {
				var resize = function() {
					_.el.css('width', Math.min(Math.round((_.el.outerWidth() / _.el.parent().outerWidth()) * 100), 100) + '%');
				};
				
				resize();
				$(window).resize(resize);
			}
			
			if(this.opts.arrows) {
				this.el.parent().append('<p class="arrows"><span class="prev">←</span><span class="next">→</span></p>')
					.find('.arrows span').click(function() {
						$.isFunction(_[this.className]) && _[this.className]();
					});
			};
			
			//  Swipe support
			if($.event.swipe) {
				this.el.on('swipeleft', _.prev).on('swiperight', _.next);
			}
		};
		
		//  Move Unslider to a slide index
		this.move = function(index, cb) {
			//  If it's out of bounds, go to the first slide
			if(!this.items.eq(index).length) index = 0;
			if(index < 0) index = (this.items.length - 1);
			
			var target = this.items.eq(index);
			var obj = {height: target.outerHeight()};
			var speed = cb ? 5 : this.opts.speed;
			
			if(!this.ul.is(':animated')) {			
				//  Handle those pesky dots
				_.el.find('.dot:eq(' + index + ')').addClass('active').siblings().removeClass('active');

				this.el.animate(obj, speed) && this.ul.animate($.extend({left: '-' + index + '00%'}, obj), speed, function(data) {
					_.current = index;
					$.isFunction(_.opts.complete) && !cb && _.opts.complete(_.el);
				});
			}
		};
		
		//  Autoplay functionality
		this.start = function() {
			_.interval = setInterval(function() {
				_.move(_.current + 1);
			}, _.opts.delay);
		};
		
		//  Stop autoplay
		this.stop = function() {
			_.interval = clearInterval(_.interval);
			return _;
		};
		
		//  Keypresses
		this.keys = function(e) {
			var key = e.which;
			var map = {
				//  Prev/next
				37: _.prev,
				39: _.next,
				
				//  Esc
				27: _.stop
			};
			
			if($.isFunction(map[key])) {
				map[key]();
			}
		};
		
		//  Arrow navigation
		this.next = function() { return _.stop().move(_.current + 1) };
		this.prev = function() { return _.stop().move(_.current - 1) };
		
		this.dots = function() {
			//  Create the HTML
			var html = '<ol class="dots">';
				$.each(this.items, function(index) { html += '<li class="dot' + (index < 1 ? ' active' : '') + '">' + (index + 1) + '</li>'; });
				html += '</ol>';
			
			//  Add it to the Unslider
			this.el.addClass('has-dots').append(html).find('.dot').click(function() {
				_.move($(this).index());
			});
		};
	};
	
	//  Create a jQuery plugin
	$.fn.unslider = function(o) {
		var len = this.length;
		//  Enable multiple-slider support
		return this.each(function(index) {
			//  Cache a copy of $(this), so it 
			var me = $(this);
			var instance = (new Unslider).init(me, o);
			
			//  Invoke an Unslider instance
			me.data('unslider' + (len > 1 ? '-' + (index + 1) : ''), instance);
		});
	};
})(window.jQuery, false);

*/

//banner
/*$(function(){
	var banr_box=$(".amaz_banr_box");
	if(banr_box.length == 0) return false;
	var banr_list=$(".amaz_list li");
	var move_dom=banr_box.find("ul");
	
	move_dom.find("li").clone().appendTo(move_dom);
	var banr_lg=move_dom.find("li").length;
	banr_box.css("height","auto");
	move_dom.css("width",banr_lg+"00%");
	move_dom.find("li").css("width",(100/banr_lg)+"%");
	var banr_indent=0;
	
	function autoplay(){
		banr_indent++;
		playbanrslide();
	}
	function contr(){
		if(banr_indent<0){
			banr_indent = banr_lg/2;
		}else if(banr_indent>=banr_lg/2){
			banr_indent = 0;
		}
		playbanrslide();
	}
	function playbanrslide(){
		if(banr_indent >= banr_lg/2){
			move_dom.animate({left:"-"+(banr_indent+"00%")},300,function(){
				move_dom.css("left","0%");
			});
			banr_indent=0;
		}else if(banr_indent<0){
			move_dom.css("left","-"+(banr_lg/2+"00%")).animate({left:"-"+(banr_lg/2-1)+"00%"},300);
			banr_indent = banr_lg/2-1;
		}else{
			move_dom.animate({left:"-"+(banr_indent+"00%")},300);
		}
		
		/*if(banr_indent <0){
			move_dom.animate({left:"-"+(banr_lg/2)+"00%"},300,function(){
				$(this).css("left","0px");
			})
			
		}else if(banr_indent == banr_lg/2 ){
			alert(banr_indent);
			move_dom.animate({left:"-"+(banr_lg/2)},300);
			move_dom.css("left","-"+(banr_lg/2+"00%")).animate({left:"-"+(banr_lg/2-1+"00%")},300);
			banr_indent--;
		}else{
			move_dom.animate({left:"-"+(banr_indent+"00%")},300);
		}*/
/*		banr_list.eq(banr_indent).addClass("currt").siblings().removeClass("currt");
		
	}

	var contral_time=setInterval(autoplay,8000);
	$(".amaz_left").click(function(){
	//	clearInterval(contral_time);
		move_dom.stop();
		banr_indent--;
		playbanrslide();
	//	contral_time=setInterval(autoplay,8000);
	});
	$(".amaz_right").click(function(){
	//	clearInterval(contral_time);
		move_dom.stop();
		banr_indent++;
		//contr();
		playbanrslide();s
	//	contral_time=setInterval(autoplay,8000);
	});
    banr_list.click(function()
	{ 
			banr_indent =$(this).index();
			move_dom.stop();
			playbanrslide();
	});

		
	
});
*/

$(function(){
	var old_sum;
	$(".wave_water").hover(function(){
		old_sum=$(this).find("span").css("height");
		$(this).find("span").stop().animate({height:"100%"},200);
	},function(){
		$(this).find("span").stop().animate({height:old_sum},200);
	});
});

$(function(){
	$(".contr_line").hover(function(){
		$(this).find(".contr_line_ln").css("width","100%");
		$(".contral_box").addClass("show_meet");
		$(".musc_twogirl").show();
	},function(){
		$(this).find(".contr_line_ln").css("width","0%");
		$(".contral_box").removeClass("show_meet");
		$(".musc_twogirl").hide();
	});
});



$(function() {
imageMouseover();
	$('.lim_lr').unbind('click').bind('click',
			function() {
				__image_slide(".show_limbox ul li", "#pre_list a", 4, 'right');
			});
	$('.lim_lf').unbind('click').bind('click',
			function() {
				__image_slide(".show_limbox ul li", "#pre_list a", 4, 'left');
			});
	function __image_slide(li, a, count, direct) {
		var panel = $(li);
		if (panel.size() < count)
			return false;
		var item;
		if (direct == 'left') {
			item = panel.eq(panel.size() - 1).remove();
			panel.parent().prepend(item);
		}
		if (direct == 'right') {
			item = panel.eq(0).remove();
			panel.parent().append(item);
		}
		imageMouseover();
	
	}
	function imageMouseover(){
		$(".sery_im li").unbind("mouseover").bind("mouseover",function(){
			var check_img=$(this).find("img").attr("check-img");
			// $(".amaz_datimg").find("img").attr("src",check_img);
			$(".amaz_datimg").find("img").attr('style','display:none');
			$(".amaz_datimg").find("img").each(function()
				{
					if($(this).attr('src') == check_img)
					{
						$(this).attr('style','display:block');
						return false ;
					}
				});
			$(this).addClass("currt").siblings().removeClass("currt");
		})
	}
	
	
	/*$(".sery_im li").live('mouseover',function(even){
		var check_img=$(this).find("img").attr("check-img");
		$(".amaz_datimg").find("img").attr("src",check_img);
		$(this).addClass("currt").siblings().removeClass("currt");
	});*/
	/*$(".sery_im li").hover(function(){
		var check_img=$(this).find("img").attr("check-img");
		$(".amaz_datimg").find("img").attr("src",check_img);
		$(this).addClass("currt").siblings().removeClass("currt");
	},function(){});*/
	$(".amaz_chag span").click(function(){
		$(this).addClass("currt").siblings().removeClass("currt");
		var amaz_indent=$(this).index();
		$(".sery_im").hide().eq(amaz_indent).fadeIn(300);
	});
})

/*多国家购买*/
$(function(){
$(".amz_buy_city a").click(function(){
		$(this).addClass("amaz_currt").siblings().removeClass("amaz_currt");
		var buylink=$(this).attr("url");
		$(".btn_box_buylink").find("a").attr("href",buylink);
	});	
})

/*top mav*/
$(function(){
	$(".amaz_navslid").hover(function(){
		$(this).addClass("currt").siblings().removeClass("currt");	
		$(".navlid_box").show();
	},function(){
		$(this).removeClass("currt");
		$(".navlid_box").hide();
		
	});	
});

$(function(){
	var head_top=$(".amaz_top_head").outerHeight();
	$(window).scroll(function(){
		var bodyscroltop = document.documentElement.scrollTop || document.body.scrollTop;
		if(bodyscroltop >= head_top){
			$(".fixmenu").addClass("fixmenu-box");
		}else{
			$(".fixmenu").removeClass("fixmenu-box");
		}
	})
	$(".amaz_menu li").hover(function(){
		$(this).find(".subfmenu").show();
	},function(){
		$(this).find(".subfmenu").hide();
	});
});

function PageScroll(name){
	if(typeof(name) == "undefined"){
		var scrollTop = 0;
	}else{
		var scrollTop = $(name)[0].offsetTop;
	}
	var nowDistance = document.documentElement.scrollTop || document.body.scrollTop;
	var disTime = 10;
	var speed = 600;
	var timing = 0;
	var oncesDistance = (scrollTop-nowDistance)*disTime/speed;
	function movPlay(){
		if(timing < speed){
			document.documentElement.scrollTop += oncesDistance;
			document.body.scrollTop +=oncesDistance;
			timing += disTime;
			setTimeout(movPlay,disTime)
		}else{
			document.documentElement.scrollTop = scrollTop;
			document.body.scrollTop = scrollTop;
		}
	}
	movPlay();
}

/*property*/
$(function(){
	$("#property_chage").change(function(){
		$(this).val();
		window.location.href=$(this).val();
	});
});

/* ScrollTopBtn */
$(window).scroll(function() {
		if ($(window).scrollTop() >= 100) {
			$('#ScrollTopBtn').addClass("ui-scrolltop_hover")
			$('#my_menu').addClass("mymenu_hover")
		} else {
			$('#ScrollTopBtn').removeClass("ui-scrolltop_hover")
			$('#my_menu').removeClass("mymenu_hover")
		}
	});

/* menu1 begin*/
$(function(){
	var time = null;
	var list = $("#navlistp");
	var box = $("#navbox");
	var lista = list.find("a");
	for(var i=0,j=lista.length;i<j;i++){
		if(lista[i].className == "now"){
			var olda = i;
		}
	}
	var box_show = function(hei){
		box.stop().animate({
			height:hei,
			opacity:1
		},400);
	}
	var box_hide = function(){
		box.stop().animate({
			height:0,
			opacity:0
		},400);
	}
	lista.hover(function(){
		lista.removeClass("now");
		$(this).addClass("now");
		clearTimeout(time);
		var index = list.find("a").index($(this));
		box.find(".cont").hide().eq(index).show();
		var _height = box.find(".cont").eq(index).height()+30;
		box_show(_height)
	},function(){
		time = setTimeout(function(){	
			box.find(".cont").hide();
			box_hide();
		},50);
		lista.removeClass("now");
		lista.eq(olda).addClass("now");
	});
	
	box.find(".cont").hover(function(){
		var _index = box.find(".cont").index($(this));
		lista.removeClass("now");
		lista.eq(_index).addClass("now");
		clearTimeout(time);
		$(this).show();
		var _height = $(this).height()+30;
		box_show(_height);
	},function(){
		time = setTimeout(function(){		
			$(this).hide();
			box_hide();
		},50);
		lista.removeClass("now");
		lista.eq(olda).addClass("now");
	});

});

/* menu2 begin*/
$(function(){
	var time = null;
	var list = $("#navlistsup");
	var box = $("#navboxsup");
	var lista = list.find("a");
	for(var i=0,j=lista.length;i<j;i++){
		if(lista[i].className == "now"){
			var olda = i;
		}
	}
	var box_show = function(hei){
		box.stop().animate({
			height:hei,
			opacity:1
		},400);
	}
	var box_hide = function(){
		box.stop().animate({
			height:0,
			opacity:0
		},400);
	}
	lista.hover(function(){
		lista.removeClass("now");
		$(this).addClass("now");
		clearTimeout(time);
		var index = list.find("a").index($(this));
		box.find(".contain").hide().eq(index).show();
		var _height = box.find(".contain").eq(index).height()+8;
		box_show(_height)
	},function(){
		time = setTimeout(function(){	
			box.find(".contain").hide();
			box_hide();
		},50);
		lista.removeClass("now");
		lista.eq(olda).addClass("now");
	});
	box.find(".contain").hover(function(){
		var _index = box.find(".contain").index($(this));
		lista.removeClass("now");
		lista.eq(_index).addClass("now");
		clearTimeout(time);
		$(this).show();
		var _height = $(this).height()+8;
		box_show(_height);
	},function(){
		time = setTimeout(function(){		
			$(this).hide();
			box_hide();
		},50);
		lista.removeClass("now");
		lista.eq(olda).addClass("now");
	});
});

/* menu3 begin*/
$(function(){
	var time = null;
	var list = $("#navlistaip");
	var box = $("#navboxaip");
	var lista = list.find("a");
	for(var i=0,j=lista.length;i<j;i++){
		if(lista[i].className == "now"){
			var olda = i;
		}
	}
	var box_show = function(hei){
		box.stop().animate({
			height:hei,
			opacity:1
		},400);
	}
	var box_hide = function(){
		box.stop().animate({
			height:0,
			opacity:0
		},400);
	}
	lista.hover(function(){
		lista.removeClass("now");
		$(this).addClass("now");
		clearTimeout(time);
		var index = list.find("a").index($(this));
		box.find(".containaip").hide().eq(index).show();
		var _height = box.find(".containaip").eq(index).height()+8;
		box_show(_height)
	},function(){
		time = setTimeout(function(){	
			box.find(".containaip").hide();
			box_hide();
		},50);
		lista.removeClass("now");
		lista.eq(olda).addClass("now");
	});
	box.find(".containaip").hover(function(){
		var _index = box.find(".containaip").index($(this));
		lista.removeClass("now");
		lista.eq(_index).addClass("now");
		clearTimeout(time);
		$(this).show();
		var _height = $(this).height()+8;
		box_show(_height);
	},function(){
		time = setTimeout(function(){		
			$(this).hide();
			box_hide();
		},50);
		lista.removeClass("now");
		lista.eq(olda).addClass("now");
	});
});



/* quick charge add animate */

$(
	function(){
	$('#qc_3 .phone_usb').on('click',function(e){$('#qc_3').addClass('ani shank');});	
	var els= ["#qc_2","#qc_3","#qc_4","#qc_5","#qc_6"];
	var $elements=[];
	var type =function(el){return Object.prototype.toString.call(el)};
	$.each(els,function(i,el){if(type($(el)[0])==='[object HTMLDivElement]'){$elements.push($(el));}});
	if($elements.length==0)return;
	var isViewIn=function(el){
		return el.getBoundingClientRect().top<$(window).height()*0.8;}
	var addAnimate=function(){
		$.each($elements,
		function(i,$el){
			if(isViewIn($el[0]))$el.addClass('animate');
			}
		);
	}
	$(window).scroll(addAnimate);
	$(window).resize(addAnimate);
	}
);	
