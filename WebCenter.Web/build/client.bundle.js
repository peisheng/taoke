/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};

/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {

/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;

/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			exports: {},
/******/ 			id: moduleId,
/******/ 			loaded: false
/******/ 		};

/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);

/******/ 		// Flag the module as loaded
/******/ 		module.loaded = true;

/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}


/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;

/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;

/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";

/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';

	/**
	 *  Copyright (c) 2015, Facebook, Inc.
	 *  All rights reserved.
	 *
	 *  This source code is licensed under the BSD-style license found in the
	 *  LICENSE file in the root directory of this source tree. An additional grant 
	 *  of patent rights can be found in the PATENTS file in the same directory.
	 */

	// All JavaScript in here will be loaded server-side

	// Expose components globally so ReactJS.NET can use them
	var Components = __webpack_require__(1);

/***/ },
/* 1 */
/***/ function(module, exports, __webpack_require__) {

	/* WEBPACK VAR INJECTION */(function(global) {module.exports = global["Components"] = __webpack_require__(2);
	/* WEBPACK VAR INJECTION */}.call(exports, (function() { return this; }())))

/***/ },
/* 2 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';

	module.exports = {
	  Avatar: __webpack_require__(3),
	  Comment: __webpack_require__(5),
	  CommentsBox: __webpack_require__(6)
	};

/***/ },
/* 3 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';

	/**
	 *  Copyright (c) 2014-Present, Facebook, Inc.
	 *  All rights reserved.
	 *
	 *  This source code is licensed under the BSD-style license found in the
	 *  LICENSE file in the root directory of this source tree. An additional grant
	 *  of patent rights can be found in the PATENTS file in the same directory.
	 */

	var React = __webpack_require__(4);

	var Avatar = React.createClass({
	  displayName: 'Avatar',

	  propTypes: {
	    author: React.PropTypes.object.isRequired
	  },
	  render: function render() {
	    return React.createElement('img', { src: this.getPhotoUrl(this.props.author),
	      alt: 'Photo of ' + this.props.author.Name,
	      width: 50,
	      height: 50,
	      className: 'commentPhoto' });
	  },
	  getPhotoUrl: function getPhotoUrl(author) {
	    return 'https://avatars.githubusercontent.com/' + author.GithubUsername + '?s=50';
	  }
	});

	module.exports = Avatar;

/***/ },
/* 4 */
/***/ function(module, exports) {

	module.exports = React;

/***/ },
/* 5 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';

	/**
	 *  Copyright (c) 2014-Present, Facebook, Inc.
	 *  All rights reserved.
	 *
	 *  This source code is licensed under the BSD-style license found in the
	 *  LICENSE file in the root directory of this source tree. An additional grant
	 *  of patent rights can be found in the PATENTS file in the same directory.
	 */

	var Avatar = __webpack_require__(3);
	var React = __webpack_require__(4);

	var Comment = React.createClass({
		displayName: 'Comment',

		propTypes: {
			author: React.PropTypes.object.isRequired
		},
		render: function render() {
			return React.createElement(
				'li',
				null,
				React.createElement(Avatar, { author: this.props.author }),
				React.createElement(
					'strong',
					null,
					this.props.author.Name
				),
				': ',
				this.props.children
			);
		}
	});

	module.exports = Comment;

/***/ },
/* 6 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';

	var Comment = __webpack_require__(5);
	var React = __webpack_require__(4);

	var CommentsBox = React.createClass({
	    displayName: 'CommentsBox',

	    propTypes: {
	        initialComments: React.PropTypes.array.isRequired
	    },
	    getInitialState: function getInitialState() {
	        return {
	            comments: this.props.initialComments,
	            page: 1,
	            hasMore: true,
	            loadingMore: false
	        };
	    },
	    loadMoreClicked: function loadMoreClicked(evt) {
	        var _this = this;

	        var nextPage = this.state.page + 1;
	        this.setState({
	            page: nextPage,
	            loadingMore: true
	        });

	        var url = evt.target.href;
	        var xhr = new XMLHttpRequest();
	        xhr.open('GET', url, true);
	        xhr.onload = function () {
	            var data = JSON.parse(xhr.responseText);
	            _this.setState({
	                comments: _this.state.comments.concat(data.comments),
	                hasMore: data.hasMore,
	                loadingMore: false
	            });
	        };
	        xhr.send();
	        evt.preventDefault();
	    },
	    render: function render() {
	        var commentNodes = this.state.comments.map(function (comment) {
	            return React.createElement(
	                Comment,
	                { author: comment.Author },
	                comment.Text
	            );
	        });
	        return React.createElement(
	            'div',
	            { className: 'comments' },
	            React.createElement(
	                'h1',
	                null,
	                'Comments'
	            ),
	            React.createElement(
	                'ol',
	                { className: 'commentList' },
	                commentNodes
	            ),
	            this.renderMoreLink()
	        );
	    },
	    renderMoreLink: function renderMoreLink() {
	        if (this.state.loadingMore) {
	            return React.createElement(
	                'em',
	                null,
	                'Loading...'
	            );
	        } else if (this.state.hasMore) {
	            return React.createElement(
	                'a',
	                { href: 'comments/page-' + (this.state.page + 1), onClick: this.loadMoreClicked },
	                'Load More'
	            );
	        } else {
	            return React.createElement(
	                'em',
	                null,
	                'No more comments'
	            );
	        }
	    }
	});

	module.exports = CommentsBox;

/***/ }
/******/ ]);