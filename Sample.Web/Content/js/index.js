jQuery(function () {
    rsblog.init();
});

var rsblog = {
    init: function () {
        this.goTop();
    },

    //回到顶部
    goTop: function () {
        //绑定滚动条事件  
        $(window).bind("scroll", function () {
            var sTop = $(window).scrollTop();
            var sTop = parseInt(sTop);
            if (sTop >= 200) {
                if (!$(".rollbar").is(":visible")) {
                    try {
                        $(".rollbar").slideDown();
                    } catch (e) {
                        $(".rollbar").show();
                    }
                }
            }
            else {
                if ($(".rollbar").is(":visible")) {
                    try {
                        $(".rollbar").slideUp();
                    } catch (e) {
                        $(".rollbar").hide();
                    }
                }
            }
        }); 

        $(".rollbar").click(function () {
            return jQuery("body,html").animate({
                scrollTop: 0
            }, 500), !1
        });
    },
};