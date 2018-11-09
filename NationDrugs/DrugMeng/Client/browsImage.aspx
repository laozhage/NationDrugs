<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="browsImage.aspx.cs" Inherits="NationDrugs.DrugMeng.Client.browsImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>Imgmove</title>
<style type="text/css">
#show{height:auto;width:700px; text-align:center; margin-bottom:15px;border:1px solid #FFFFFF;display: inline-table}
#show img{ text-align:center; }
#container{  height:auto; width:613px; text-align:center; display: inline-table}
#left{ height:97px; width:24px; float:left; background-image:url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453754.p.gif); margin-top:5px; margin-right:10px;}
#middle{ height:109px;  width:545px; float:left; overflow:hidden;}
#thumblist{ width:1090px;}
#thumblist div { width:109px; height:109px; text-align:center; float:left}
.cc{width:109px; height:109px; text-align:center; float:left; background-image:url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011452785.p.gif)}
#thumblist div span { width:95px; height:95px; margin:6px !important;margin:3px; margin-top:6px; border:1px solid #FFFFFF; background-color:#000000; vertical-align:middle; line-height:95px; display:block}
#thumblist div span img { width:100%; height:100%; display:block}
#right{height:97px; width:24px; float:left;  background-image:url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453926.p.gif);margin-top:5px; margin-left:10px}
</style>
</head>
<body style="background-color:#FFFFFF; text-align:center" >

<div id="container">
    <div id='show'><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012812035.p.gif'></div>
    <div id="left"></div>
    <div id="middle">
        <div id="thumblist">
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012811863.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012811894.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012812035.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012811457.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012811769.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012811738.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012811613.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012811566.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012811472.p.gif'></span>
			</div>
			<div >
			   <span><img src ='http://album.hi.csdn.net/app_uploads/wtcsy/20090622/012812004.p.gif'></span>
			</div>																																						
		</div>
    </div>
    <div id="right"></div>
</div>
<%--<div>
<input value='聚焦第1张图片' type="button" onclick="sss(1)" />
<input value='聚焦第2张图片' type="button" onclick="sss(2)"/>
<input value='聚焦第3张图片' type="button" onclick="sss(3)"/>
<input value='聚焦第4张图片' type="button" onclick="sss(4)"/>
<input value='聚焦第5张图片' type="button" onclick="sss(5)"/>
</div>--%>
<script type="text/javascript">


    document.all && document.execCommand("BackgroundImageCache", false, true);

    var isIE = (document.all) ? true : false;

    var $ = function (id) {
        return document.getElementById(id);
    };

    var Extend = function (destination, source) {
        for (var property in source) {
            destination[property] = source[property];
        }
    }

    var Bind = function (object, fun, args) {
        return function () {
            return fun.apply(object, args || []);
        }
    }

    var BindAsEventListener = function (object, fun) {
        var args = Array.prototype.slice.call(arguments).slice(2);
        return function (event) {
            return fun.apply(object, [event || window.event].concat(args));
        }
    }

    var CurrentStyle = function (element) {
        return element.currentStyle || document.defaultView.getComputedStyle(element, null);
    }

    var Tween = {
        Quart: {
            easeOut: function (t, b, c, d) {
                return -c * ((t = t / d - 1) * t * t * t - 1) + b;
            }
        }
    }

    function create(elm, parent, fn) { var element = document.createElement(elm); fn && fn(element); parent && parent.appendChild(element); return element };
    function addListener(element, e, fn) { element.addEventListener ? element.addEventListener(e, fn, false) : element.attachEvent("on" + e, fn) };
    function removeListener(element, e, fn) { element.removeEventListener ? element.removeEventListener(e, fn, false) : element.detachEvent("on" + e, fn) };

    var Class = function (properties) {
        var _class = function () { return (arguments[0] !== null && this.initialize && typeof (this.initialize) == 'function') ? this.initialize.apply(this, arguments) : this; };
        _class.prototype = properties;
        return _class;
    };

    var Imgroll = new Class({
        options: {
            Isrun: false,   //判断是否正在滚动
            Step: 100,
            Time: 10,
            t: 0,
            b: 0,
            c: 0,
            d: 60,
            Tween: Tween.Quart.easeOut,
            Oninit: function () { },
            Onstart: function () { },
            Onstop: function () { }
        },
        initialize: function (show, obj, c, total, i, options) {
            this._show = show    //代表大图的那个div
            this._obj = obj;
            this._c = c;
            this._total = total;
            this.i = i;
            this.o = '';   //记录图片背景的
            this.timer = null;
            this.Isrun = this.options.isrun;
            this.Step = this.options.Step;
            this.Time = this.options.Time;
            this.t = this.options.t;
            this.b = this.options.b;
            this.c = this.options.c;
            this.d = this.options.d;
            this.Tween = this.options.Tween;
            this.Oninit = this.options.Oninit;
            this.Onstart = this.options.Onstart;
            this.Onstop = this.options.Onstop;
            Extend(this, options || {});
            var self = this, i = 0, img = this._c.getElementsByTagName('div');
            this.o = img[this.i - 1];
            this.o.className = "cc";
            for (; i < img.length; i++) {
                img[i].num = i;
                (function (i) {
                    addListener(img[i], 'click', Bind(self, self.Start, [img[i]]));
                })(i);
            }
        },
        Start: function (c) {
            if (this.Isrun) return;
            this.Isrun = true;
            var img = this._c.getElementsByTagName('div')
            this.b = this._obj.scrollLeft;
            if (c) {
                /*if(c.num<this.i)
                {
                this.c =  -1*(this.b);
                }
                else if(c.num>img.length-1-this._total+this.i)  
                {
                this.c =(img.length - this._total)*this.Step - this.b 
                }
                else
                {
                this.c = (c.num-this.i+1)*this.Step-this.b;
                }*/
                this.c = c.num < this.i ? (-1) * this.b : (c.num > img.length - 1 - this._total + this.i ? (img.length - this._total) * this.Step - this.b : (c.num - this.i + 1) * this.Step - this.b)

            }

            this.Onstart(c);
            this.Run();
        },
        Run: function () {
            if (this.t < this.d) {
                this.RunTo(Math.round(this.Tween(++this.t, this.b, this.c, this.d)))
                this.timer = setTimeout(Bind(this, this.Run), this.Time)
            }
            else {
                this.RunTo(this.b + this.c);
                this.Stop();
            }
        },
        RunTo: function (i) {
            this._obj.scrollLeft = i;
        },
        Pre: function () {
            this.c = this.Step * (-1);
            this.Start();
        },
        Next: function () {
            this.c = this.Step;
            this.Start();
        },
        Stop: function () {
            clearTimeout(this.timer);
            this.t = 0; this.Isrun = false;
            this.Onstop()
        }
    })

    var ss = new Imgroll($('show'), $('middle'), $('thumblist'), 5, 3, {
        Step: 109,   //着里的109是指中间每个包含div图片的宽度,也可以写成$('thumblist').getElementsByTagName('div')[0].offsetWidth;
        Onstart: function (obj) {
            if (!obj) return;
            ss._show.getElementsByTagName('img')[0].src = obj.getElementsByTagName('img')[0].src;
            this.o.className = ''
            this.o = obj;
            obj.className = 'cc';
        },
        Onstop: function () {
            $('left').style.backgroundImage = this._obj.scrollLeft == 0 ? "url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453754.p.gif)" : "url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453879.p.gif)";
            $('right').style.backgroundImage = this._obj.scrollLeft == 545 ? "url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453832.p.gif)" : "url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453926.p.gif)";
        } 
    });
    addListener($('right'), 'mousedown', function () { ss.Next() });
    addListener($('right'), 'mouseover', function () { cbg1(1) });
    addListener($('right'), 'mouseout', function () { cbg1(0) });
    addListener($('left'), 'mousedown', function () { ss.Pre() });
    addListener($('left'), 'mouseover', function () { cbg(1) });
    addListener($('left'), 'mouseout', function () { cbg(0) });
    function cbg(n) {
        if (ss._obj.scrollLeft == 0) return;
        $('left').style.backgroundImage = n ? "url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453941.p.gif)" : "url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453879.p.gif)"
    }
    function cbg1(n) {
        if (ss._obj.scrollLeft == 545) return;
        $('right').style.backgroundImage = n ? "url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453957.p.gif)" : "url(http://album.hi.csdn.net/app_uploads/wtcsy/20090622/011453926.p.gif)"
    }

    function sss(num) {
        ss.i = num;
    }
</script>
</body>
</html>