module.exports=__NEXT_REGISTER_PAGE("/service",function(){var e=webpackJsonp([13],{1147:function(e,t,r){e.exports=r(1148)},1148:function(e,t,r){"use strict";Object.defineProperty(t,"__esModule",{value:true});var n=r(28);var a=r.n(n);var o=r(0);var i=r.n(o);var s=r(91);var u=r(52);var c=r(55);var l=r(72);var p=r(58);var f=r(103);function v(e){return function(){var t=this,r=arguments;return new Promise(function(n,a){var o=e.apply(t,r);function i(e,t){try{var r=o[e](t);var i=r.value}catch(e){a(e);return}r.done?n(i):Promise.resolve(i).then(s,u)}function s(e){i("next",e)}function u(e){i("throw",e)}s()})}}var d=r(49);var h=function e(t){var r=t.pathname,n=t.companyInfo,a=t.post,o=t.posts,u=t.aboutList,c=t.token,f=t.services,v=t.popularTrip;return i.a.createElement(s["a"],{companyInfo:n,services:f,token:c,aboutList:u,popularTrip:v},i.a.createElement("div",{class:"f6 ph3 ph6-l center darkblue"},i.a.createElement(l["a"],{post:a,postType:"news"}),i.a.createElement(p["a"],{posts:o})))};h.getInitialProps=function(){var e=v(a.a.mark(function e(t){var r,n,o,i,s,l,p,f,v,d,h;return a.a.wrap(function e(a){while(1)switch(a.prev=a.next){case 0:r=t.ctx,n=r.pathname,o=r.query,i=r.req;s=t.token;l=t.aboutList;p=t.companyInfo;a.next=6;return Object(c["a"])({slug:o.slug,companyInfo:p.subdomain});case 6:f=a.sent;a.next=9;return Object(u["b"])({per_page:4,page:1,_embed:true,companyInfo:p.subdomain});case 9:v=a.sent;v=v.data;d=t.services;l=t.aboutList;h=t.popularTrip;return a.abrupt("return",{pathname:n,companyInfo:p,aboutList:l,popularTrip:h,post:{title:f.title.rendered,date:f.date.substring(0,10),content:f.content.rendered},token:s,posts:v,services:d});case 15:case"end":return a.stop()}},e,this)}));return function(t){return e.apply(this,arguments)}}();t["default"]=h},44:function(e,t,r){e.exports=r(92)},52:function(e,t,r){"use strict";t["b"]=l;t["a"]=p;var n=r(28);var a=r.n(n);var o=r(71);var i=r.n(o);var s=r(43);var u=r.n(s);function c(e){return function(){var t=this,r=arguments;return new Promise(function(n,a){var o=e.apply(t,r);function i(e,t){try{var r=o[e](t);var i=r.value}catch(e){a(e);return}r.done?n(i):Promise.resolve(i).then(s,u)}function s(e){i("next",e)}function u(e){i("throw",e)}s()})}}function l(e){var t="https://".concat(e.companyInfo,".vexere.net/wp-json/wp/v2");e.per_page=e.per_page||10;e.page=e.page||1;return i()("".concat(t,"/posts?per_page=").concat(e.per_page,"&page=").concat(e.page,"&_embed=").concat(e._embed)).then(function(){var e=c(a.a.mark(function e(t){var r;return a.a.wrap(function e(n){while(1)switch(n.prev=n.next){case 0:n.next=2;return t.json();case 2:r=n.sent;return n.abrupt("return",{totalPages:t.headers.get("x-wp-totalpages"),data:r});case 4:case"end":return n.stop()}},e,this)}));return function(t){return e.apply(this,arguments)}}())}function p(e){var t="https://".concat(e.companyInfo,".vexere.net/wp-json/wp/v2");return i()("".concat(t,"/posts?slug=").concat(e.slug,"&_embed=").concat(e._embed)).then(function(){var e=c(a.a.mark(function e(t){return a.a.wrap(function e(r){while(1)switch(r.prev=r.next){case 0:r.next=2;return t.json();case 2:return r.abrupt("return",r.sent[0]);case 3:case"end":return r.stop()}},e,this)}));return function(t){return e.apply(this,arguments)}}())}function f(e){e.per_page=e.per_page||10;var t="https://".concat(e.companyInfo,".vexere.net/wp-json/wp/v2");e.page=e.page||1;return i()("".concat(t,"/posts?parent=").concat(e.parent,"per_page=").concat(e.per_page,"&page=").concat(e.page,"&_embed=").concat(e._embed)).then(function(){var e=c(a.a.mark(function e(t){return a.a.wrap(function e(r){while(1)switch(r.prev=r.next){case 0:r.next=2;return t.json();case 2:return r.abrupt("return",r.sent);case 3:case"end":return r.stop()}},e,this)}));return function(t){return e.apply(this,arguments)}}())}},58:function(e,t,r){"use strict";var n=r(0);var a=r.n(n);function o(e){o="function"===typeof Symbol&&"symbol"===typeof Symbol.iterator?function e(t){return typeof t}:function e(t){return t&&"function"===typeof Symbol&&t.constructor===Symbol&&t!==Symbol.prototype?"symbol":typeof t};return o(e)}function i(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function s(e,t){for(var r=0;r<t.length;r++){var n=t[r];n.enumerable=n.enumerable||false;n.configurable=true;"value"in n&&(n.writable=true);Object.defineProperty(e,n.key,n)}}function u(e,t,r){t&&s(e.prototype,t);r&&s(e,r);return e}function c(e,t){if(t&&("object"===o(t)||"function"===typeof t))return t;return p(e)}function l(e,t){if("function"!==typeof t&&null!==t)throw new TypeError("Super expression must either be null or a function");e.prototype=Object.create(t&&t.prototype,{constructor:{value:e,enumerable:false,writable:true,configurable:true}});t&&(Object.setPrototypeOf?Object.setPrototypeOf(e,t):e.__proto__=t)}function p(e){if(void 0===e)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return e}var f=function(e){l(t,e);function t(e){var r;i(this,t);r=c(this,(t.__proto__||Object.getPrototypeOf(t)).call(this,e));r.toggleClass=r.toggleClass.bind(p(r));r.state={tab1Active:true,tab2Active:false};return r}u(t,[{key:"toggleClass",value:function e(t){this.setState({tab1Active:"tab-most-reads"==t.target.id,tab2Active:"tab-most-reads"!=t.target.id})}},{key:"getImageSource",value:function e(t){var r=[{media_details:{sizes:{thumbnail:{source_url:"/static/img/driver.png"}}}}];var n=t._embedded["wp:featuredmedia"]||r;return n[0].media_details.sizes.thumbnail.source_url}},{key:"render",value:function e(){var t=this;var r=this.props.posts;var n=a.a.createElement("div",{class:"w-30 fr pl4-l dn db-l"},a.a.createElement("div",null,a.a.createElement("div",{class:"flex mb3"},a.a.createElement("div",{id:"tab-most-reads",class:"w-50 tab-news-header dib f5 b ttu pa2 pointer bw1 tc"+(this.state.tab1Active?" bt b--blue blue":" bt b--light-gray bg-vxr-gray"),onClick:this.toggleClass},"Đọc nhiều"),a.a.createElement("div",{id:"tab-recent-news",class:"w-50 tab-news-header dib w-50 f5 b ttu pa2 pointer bw1 tc"+(this.state.tab2Active?" bt b--blue blue":" bt b--light-gray bg-vxr-gray"),onClick:this.toggleClass},"Bài mới")),a.a.createElement("div",{id:"divMostReads",class:"tab-news"+(this.state.tab1Active?" db":" dn")},r.map(function(e,r){return a.a.createElement("article",{class:"pv2 bt bb b--black-10 ph3 ph0-l"},a.a.createElement("div",{class:"flex flex-column flex-row-ns"},a.a.createElement("div",{class:"w-100 w-60-ns pr3-ns order-2 order-2-ns"},a.a.createElement("h1",{class:"f6 sans-serif mt0 lh-title"},a.a.createElement("a",{class:"link dim dark-gray",href:"/tin-tuc/"+e.slug},e.title.rendered))),a.a.createElement("div",{class:"pr3-ns order-1 order-1-ns mw4 mb4 mb0-ns w-100 w-70-ns"},a.a.createElement("a",{href:e.slug},a.a.createElement("img",{src:t.getImageSource(e),class:"db",alt:e.title.rendered})))),a.a.createElement("time",{class:"f6 db gray"},e.date))})),a.a.createElement("div",{id:"divRecentNews",class:"tab-news"+(this.state.tab2Active?" db":" dn")},r.map(function(e,r){return a.a.createElement("article",{class:"pv2 bt bb b--black-10 ph3 ph0-l"},a.a.createElement("div",{class:"flex flex-column flex-row-ns"},a.a.createElement("div",{class:"w-100 w-60-ns pr3-ns order-2 order-2-ns"},a.a.createElement("h1",{class:"f6 sans-serif mt0 lh-title"},a.a.createElement("a",{class:"link dim dark-gray",href:"/tin-tuc/"+e.slug},e.title.rendered))),a.a.createElement("div",{class:"pr3-ns order-1 order-1-ns mw4 mb4 mb0-ns w-100 w-70-ns"},a.a.createElement("a",{href:e.slug},a.a.createElement("img",{src:t.getImageSource(e),class:"db",alt:e.title.rendered})))),a.a.createElement("time",{class:"f6 db gray"},e.date))}))));return n}}]);return t}(a.a.Component);t["a"]=f},72:function(e,t,r){"use strict";var n=r(0);var a=r.n(n);var o=r(73);var i=r.n(o);function s(){s=Object.assign||function(e){for(var t=1;t<arguments.length;t++){var r=arguments[t];for(var n in r)Object.prototype.hasOwnProperty.call(r,n)&&(e[n]=r[n])}return e};return s.apply(this,arguments)}var u=function e(t){return a.a.createElement("div",s({class:"fl w-100 w-70-l tj  ph3 ph0-l"},t))};var c=u;var l=function e(t){var r=t.postType,n=t.post;return a.a.createElement(c,null,a.a.createElement("h1",{class:"f3 lh-title post-title"},n.title),"news"===r&&a.a.createElement("p",{class:"tr right"},n.date),a.a.createElement("div",{class:"f6 lh-copy color ",dangerouslySetInnerHTML:{__html:n.content}}))};var p=t["a"]=l},73:function(e,t,r){var n=r(74);var a=e.exports=n();a.add("index","/");a.add("about","/gioi-thieu");a.add("fare","/bang-gia");a.add("services","/dich-vu");a.add("service","/dich-vu/:slug");a.add("aboutList","/gioi-thieu/:slug");a.add("post","/tin-tuc/:slug");a.add("posts","/tin-tuc");a.add("contact","/lien-he");a.add("faq","/faqs");a.add("booking","/dat-ve-truc-tuyen");a.add("searchTicketResult","/danh-sach-ve");a.add("cancelTicket","/huy-ve");a.add("checkTicket","/kiem-tra-ve");a.add("viewUserInfo","/thong-tin");a.add("ticketHistory","/lich-su-dat-ve");a.add("changeUserInfo","/thay-doi-thong-tin")},74:function(e,t,r){"use strict";var n=u(r(75));var a=u(r(0));var o=r(144);var i=u(r(102));var s=u(r(44));function u(e){return e&&e.__esModule?e:{default:e}}function c(e,t){if(null==e)return{};var r={};var n=Object.keys(e);var a,o;for(o=0;o<n.length;o++){a=n[o];if(t.indexOf(a)>=0)continue;r[a]=e[a]}if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(o=0;o<i.length;o++){a=i[o];if(t.indexOf(a)>=0)continue;if(!Object.prototype.propertyIsEnumerable.call(e,a))continue;r[a]=e[a]}}return r}function l(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};var n=Object.keys(r);"function"===typeof Object.getOwnPropertySymbols&&(n=n.concat(Object.getOwnPropertySymbols(r).filter(function(e){return Object.getOwnPropertyDescriptor(r,e).enumerable})));n.forEach(function(t){p(e,t,r[t])})}return e}function p(e,t,r){t in e?Object.defineProperty(e,t,{value:r,enumerable:true,configurable:true,writable:true}):e[t]=r;return e}function f(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}function v(e,t){for(var r=0;r<t.length;r++){var n=t[r];n.enumerable=n.enumerable||false;n.configurable=true;"value"in n&&(n.writable=true);Object.defineProperty(e,n.key,n)}}function d(e,t,r){t&&v(e.prototype,t);r&&v(e,r);return e}e.exports=function(e){return new h(e)};var h=function(){function e(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{},r=t.Link,n=void 0===r?i.default:r,a=t.Router,o=void 0===a?s.default:a;f(this,e);this.routes=[];this.Link=this.getLink(n);this.Router=this.getRouter(o)}d(e,[{key:"add",value:function e(t,r,n){var a;if(t instanceof Object){a=t;t=a.name}else{if("/"===t[0]){n=r;r=t;t=null}a={name:t,pattern:r,page:n}}if(this.findByName(t))throw new Error('Route "'.concat(t,'" already exists'));this.routes.push(new m(a));return this}},{key:"findByName",value:function e(t){if(t)return this.routes.filter(function(e){return e.name===t})[0]}},{key:"match",value:function e(t){var r=(0,o.parse)(t,true);var n=r.pathname,a=r.query;return this.routes.reduce(function(e,t){if(e.route)return e;var r=t.match(n);if(!r)return e;return l({},e,{route:t,params:r,query:l({},a,r)})},{query:a,parsedUrl:r})}},{key:"findAndGetUrls",value:function e(t,r){var n=this.findByName(t);if(n)return{route:n,urls:n.getUrls(r),byName:true};var a=this.match(t),o=a.route,i=a.query;var s=o?o.getHref(i):t;var u={href:s,as:t};return{route:o,urls:u}}},{key:"getRequestHandler",value:function e(t,r){var n=this;var a=t.getRequestHandler();return function(e,o){var i=n.match(e.url),s=i.route,u=i.query,c=i.parsedUrl;s?r?r({req:e,res:o,route:s,query:u}):t.render(e,o,s.page,u):a(e,o,c)}}},{key:"getLink",value:function e(t){var r=this;var n=function e(n){var o=n.route,i=n.params,s=n.to,u=c(n,["route","params","to"]);var l=o||s;l&&Object.assign(u,r.findAndGetUrls(l,i).urls);return a.default.createElement(t,u)};return n}},{key:"getRouter",value:function e(t){var r=this;var n=function e(n){return function(e,a,o){var i=r.findAndGetUrls(e,a),s=i.byName,u=i.urls,c=u.as,l=u.href;return t[n](l,c,s?o:a)}};t.pushRoute=n("push");t.replaceRoute=n("replace");t.prefetchRoute=n("prefetch");return t}}]);return e}();var m=function(){function e(t){var r=t.name,a=t.pattern,o=t.page,i=void 0===o?r:o;f(this,e);if(!r&&!i)throw new Error('Missing page to render for route "'.concat(a,'"'));this.name=r;this.pattern=a||"/".concat(r);this.page=i.replace(/(^|\/)index$/,"").replace(/^\/?/,"/");this.regex=(0,n.default)(this.pattern,this.keys=[]);this.keyNames=this.keys.map(function(e){return e.name});this.toPath=n.default.compile(this.pattern)}d(e,[{key:"match",value:function e(t){var r=this.regex.exec(t);if(r)return this.valuesToParams(r.slice(1))}},{key:"valuesToParams",value:function e(t){var r=this;return t.reduce(function(e,t,n){if(void 0===t)return e;return Object.assign(e,p({},r.keys[n].name,decodeURIComponent(t)))},{})}},{key:"getHref",value:function e(){var t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};return"".concat(this.page,"?").concat(g(t))}},{key:"getAs",value:function e(){var t=this;var r=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};var n=this.toPath(r)||"/";var a=Object.keys(r);var o=a.filter(function(e){return-1===t.keyNames.indexOf(e)});if(!o.length)return n;var i=o.reduce(function(e,t){return Object.assign(e,p({},t,r[t]))},{});return"".concat(n,"?").concat(g(i))}},{key:"getUrls",value:function e(t){var r=this.getAs(t);var n=this.getHref(t);return{as:r,href:n}}}]);return e}();var g=function e(t){return Object.keys(t).filter(function(e){return null!==t[e]&&void 0!==t[e]}).map(function(e){var r=t[e];Array.isArray(r)&&(r=r.join("/"));return[encodeURIComponent(e),encodeURIComponent(r)].join("=")}).join("&")}},75:function(e,t){e.exports=h;e.exports.parse=o;e.exports.compile=i;e.exports.tokensToFunction=s;e.exports.tokensToRegExp=d;var r="/";var n="./";var a=new RegExp(["(\\\\.)","(?:\\:(\\w+)(?:\\(((?:\\\\.|[^\\\\()])+)\\))?|\\(((?:\\\\.|[^\\\\()])+)\\))([+*?])?"].join("|"),"g");function o(e,t){var o=[];var i=0;var s=0;var l="";var p=t&&t.delimiter||r;var f=t&&t.delimiters||n;var v=false;var d;while(null!==(d=a.exec(e))){var h=d[0];var m=d[1];var g=d.index;l+=e.slice(s,g);s=g+h.length;if(m){l+=m[1];v=true;continue}var b="";var y=e[s];var w=d[2];var x=d[3];var E=d[4];var k=d[5];if(!v&&l.length){var j=l.length-1;if(f.indexOf(l[j])>-1){b=l[j];l=l.slice(0,j)}}if(l){o.push(l);l="";v=false}var O=""!==b&&void 0!==y&&y!==b;var _="+"===k||"*"===k;var R="?"===k||"*"===k;var P=b||p;var T=x||E;o.push({name:w||i++,prefix:b,delimiter:P,optional:R,repeat:_,partial:O,pattern:T?c(T):"[^"+u(P)+"]+?"})}(l||s<e.length)&&o.push(l+e.substr(s));return o}function i(e,t){return s(o(e,t))}function s(e){var t=new Array(e.length);for(var r=0;r<e.length;r++)"object"===typeof e[r]&&(t[r]=new RegExp("^(?:"+e[r].pattern+")$"));return function(r,n){var a="";var o=n&&n.encode||encodeURIComponent;for(var i=0;i<e.length;i++){var s=e[i];if("string"===typeof s){a+=s;continue}var u=r?r[s.name]:void 0;var c;if(Array.isArray(u)){if(!s.repeat)throw new TypeError('Expected "'+s.name+'" to not repeat, but got array');if(0===u.length){if(s.optional)continue;throw new TypeError('Expected "'+s.name+'" to not be empty')}for(var l=0;l<u.length;l++){c=o(u[l],s);if(!t[i].test(c))throw new TypeError('Expected all "'+s.name+'" to match "'+s.pattern+'"');a+=(0===l?s.prefix:s.delimiter)+c}continue}if("string"===typeof u||"number"===typeof u||"boolean"===typeof u){c=o(String(u),s);if(!t[i].test(c))throw new TypeError('Expected "'+s.name+'" to match "'+s.pattern+'", but got "'+c+'"');a+=s.prefix+c;continue}if(s.optional){s.partial&&(a+=s.prefix);continue}throw new TypeError('Expected "'+s.name+'" to be '+(s.repeat?"an array":"a string"))}return a}}function u(e){return e.replace(/([.+*?=^!:${}()[\]|/\\])/g,"\\$1")}function c(e){return e.replace(/([=!:$/()])/g,"\\$1")}function l(e){return e&&e.sensitive?"":"i"}function p(e,t){if(!t)return e;var r=e.source.match(/\((?!\?)/g);if(r)for(var n=0;n<r.length;n++)t.push({name:n,prefix:null,delimiter:null,optional:false,repeat:false,partial:false,pattern:null});return e}function f(e,t,r){var n=[];for(var a=0;a<e.length;a++)n.push(h(e[a],t,r).source);return new RegExp("(?:"+n.join("|")+")",l(r))}function v(e,t,r){return d(o(e,r),t,r)}function d(e,t,a){a=a||{};var o=a.strict;var i=false!==a.end;var s=u(a.delimiter||r);var c=a.delimiters||n;var p=[].concat(a.endsWith||[]).map(u).concat("$").join("|");var f="";var v=0===e.length;for(var d=0;d<e.length;d++){var h=e[d];if("string"===typeof h){f+=u(h);v=d===e.length-1&&c.indexOf(h[h.length-1])>-1}else{var m=u(h.prefix);var g=h.repeat?"(?:"+h.pattern+")(?:"+m+"(?:"+h.pattern+"))*":h.pattern;t&&t.push(h);h.optional?h.partial?f+=m+"("+g+")?":f+="(?:"+m+"("+g+"))?":f+=m+"("+g+")"}}if(i){o||(f+="(?:"+s+")?");f+="$"===p?"$":"(?="+p+")"}else{o||(f+="(?:"+s+"(?="+p+"))?");v||(f+="(?="+s+"|"+p+")")}return new RegExp("^"+f,l(a))}function h(e,t,r){if(e instanceof RegExp)return p(e,t);if(Array.isArray(e))return f(e,t,r);return v(e,t,r)}}},[1147]);return{page:e.default}});