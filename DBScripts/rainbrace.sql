/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50536
Source Host           : localhost:3306
Source Database       : rainbrace

Target Server Type    : MYSQL
Target Server Version : 50536
File Encoding         : 65001

Date: 2016-06-10 11:44:10
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for category
-- ----------------------------
DROP TABLE IF EXISTS `category`;
CREATE TABLE `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(255) DEFAULT NULL,
  `parent_id` int(11) DEFAULT NULL,
  `sort` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of category
-- ----------------------------
INSERT INTO `category` VALUES ('1', 'categoruy ddd', null, '1');
INSERT INTO `category` VALUES ('4', 'Audio', null, '0');
INSERT INTO `category` VALUES ('5', 'Mobile Accessories', null, '0');
INSERT INTO `category` VALUES ('6', 'Auto Accessories', null, '0');
INSERT INTO `category` VALUES ('7', 'Cables & Hubs', null, '0');

-- ----------------------------
-- Table structure for contact_msg
-- ----------------------------
DROP TABLE IF EXISTS `contact_msg`;
CREATE TABLE `contact_msg` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `country_id` varchar(255) DEFAULT NULL,
  `msg_type` varchar(255) DEFAULT NULL,
  `subject` varchar(255) DEFAULT NULL,
  `content` varchar(2000) DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `is_read` int(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of contact_msg
-- ----------------------------
INSERT INTO `contact_msg` VALUES ('1', 'sdfasd', null, null, 'sadfas', null, 'sdfs', null, null, null);
INSERT INTO `contact_msg` VALUES ('2', 'sddfasdf', null, null, null, null, 'sdfsdf', null, null, '1');
INSERT INTO `contact_msg` VALUES ('3', 'sdfasd', '121', '1212', null, null, 'asasdas', 'Contact Us\r\nCustomer Service\r\nIf you need help or have questions about your order, please contact our support team at support@aukey.com\r\n\r\nMedia and Press Inquiries\r\nFor questions related to events, interviews, or brand content please contact marketing@aukey.com\r\n\r\nBusiness Inquiries\r\nFor wholesale questions including international distribution please contact wholesale@aukey.com\r\n\r\n', null, '1');
INSERT INTO `contact_msg` VALUES ('4', 'sdfasdf', null, null, null, null, null, null, null, '1');
INSERT INTO `contact_msg` VALUES ('5', 'asd', null, 'asdasd', null, null, 'asda', 'sdasd', '2016-06-09 23:35:16', '0');

-- ----------------------------
-- Table structure for dictionary
-- ----------------------------
DROP TABLE IF EXISTS `dictionary`;
CREATE TABLE `dictionary` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `value` varchar(255) DEFAULT NULL,
  `group` varchar(50) DEFAULT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of dictionary
-- ----------------------------

-- ----------------------------
-- Table structure for image
-- ----------------------------
DROP TABLE IF EXISTS `image`;
CREATE TABLE `image` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `image_name` varchar(255) DEFAULT NULL,
  `image_path` varchar(255) DEFAULT NULL,
  `small_path` varchar(255) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `image_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=122 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of image
-- ----------------------------
INSERT INTO `image` VALUES ('73', '08-10-24-68195ea.jpg', '/Uploads/2016-06-04/08-10-24-68195ea.jpg', '/Uploads/2016-06-04/08-10-24-68195ea_450_300.jpg', null, '2016-06-04 20:10:24');
INSERT INTO `image` VALUES ('74', '08-10-24-200fd20.jpg', '/Uploads/2016-06-04/08-10-24-200fd20.jpg', '/Uploads/2016-06-04/08-10-24-200fd20_450_300.jpg', null, '2016-06-04 20:10:24');
INSERT INTO `image` VALUES ('75', '08-10-24-447042c.jpg', '/Uploads/2016-06-04/08-10-24-447042c.jpg', '/Uploads/2016-06-04/08-10-24-447042c_450_300.jpg', null, '2016-06-04 20:10:24');
INSERT INTO `image` VALUES ('76', '08-10-25-1061e06.jpg', '/Uploads/2016-06-04/08-10-25-1061e06.jpg', '/Uploads/2016-06-04/08-10-25-1061e06_450_300.jpg', null, '2016-06-04 20:10:25');
INSERT INTO `image` VALUES ('77', '08-19-08-636b184.jpg', '/Uploads/2016-06-04/08-19-08-636b184.jpg', '/Uploads/2016-06-04/08-19-08-636b184_450_300.jpg', null, '2016-06-04 20:19:08');
INSERT INTO `image` VALUES ('78', '08-19-15-739ba89.jpg', '/Uploads/2016-06-04/08-19-15-739ba89.jpg', '/Uploads/2016-06-04/08-19-15-739ba89_450_300.jpg', null, '2016-06-04 20:19:15');
INSERT INTO `image` VALUES ('79', '08-19-15-7916052.jpg', '/Uploads/2016-06-04/08-19-15-7916052.jpg', '/Uploads/2016-06-04/08-19-15-7916052_450_300.jpg', null, '2016-06-04 20:19:15');
INSERT INTO `image` VALUES ('80', '08-19-15-3105a9f.jpg', '/Uploads/2016-06-04/08-19-15-3105a9f.jpg', '/Uploads/2016-06-04/08-19-15-3105a9f_450_300.jpg', null, '2016-06-04 20:19:15');
INSERT INTO `image` VALUES ('81', '08-19-16-251766c.jpg', '/Uploads/2016-06-04/08-19-16-251766c.jpg', '/Uploads/2016-06-04/08-19-16-251766c_450_300.jpg', null, '2016-06-04 20:19:16');
INSERT INTO `image` VALUES ('82', '08-22-49-167d48b.jpg', '/Uploads/2016-06-04/08-22-49-167d48b.jpg', '/Uploads/2016-06-04/08-22-49-167d48b_450_300.jpg', '2', '2016-06-04 20:22:49');
INSERT INTO `image` VALUES ('83', '08-22-49-4143088.jpg', '/Uploads/2016-06-04/08-22-49-4143088.jpg', '/Uploads/2016-06-04/08-22-49-4143088_450_300.jpg', '2', '2016-06-04 20:22:49');
INSERT INTO `image` VALUES ('84', '08-22-50-46781ad.jpg', '/Uploads/2016-06-04/08-22-50-46781ad.jpg', '/Uploads/2016-06-04/08-22-50-46781ad_450_300.jpg', '2', '2016-06-04 20:22:50');
INSERT INTO `image` VALUES ('85', '08-22-50-738428.jpg', '/Uploads/2016-06-04/08-22-50-738428.jpg', '/Uploads/2016-06-04/08-22-50-738428_450_300.jpg', '2', '2016-06-04 20:22:50');
INSERT INTO `image` VALUES ('87', '10-19-02-2387b7a.jpg', '/Uploads/2016-06-04/10-19-02-2387b7a.jpg', '/Uploads/2016-06-04/10-19-02-2387b7a_450_300.jpg', null, '2016-06-04 22:19:02');
INSERT INTO `image` VALUES ('88', '10-29-39-6831d60.jpg', '/Uploads/2016-06-04/10-29-39-6831d60.jpg', '/Uploads/2016-06-04/10-29-39-6831d60_450_300.jpg', null, '2016-06-04 22:29:39');
INSERT INTO `image` VALUES ('89', '10-30-15-7086a4e.jpg', '/Uploads/2016-06-04/10-30-15-7086a4e.jpg', '/Uploads/2016-06-04/10-30-15-7086a4e_450_300.jpg', null, '2016-06-04 22:30:15');
INSERT INTO `image` VALUES ('90', '10-30-58-60351fc.jpg', '/Uploads/2016-06-04/10-30-58-60351fc.jpg', '/Uploads/2016-06-04/10-30-58-60351fc_450_300.jpg', null, '2016-06-04 22:30:58');
INSERT INTO `image` VALUES ('91', '10-31-47-531be9a.jpg', '/Uploads/2016-06-04/10-31-47-531be9a.jpg', '/Uploads/2016-06-04/10-31-47-531be9a_450_300.jpg', null, '2016-06-04 22:31:47');
INSERT INTO `image` VALUES ('92', '10-31-48-8169932.jpg', '/Uploads/2016-06-04/10-31-48-8169932.jpg', '/Uploads/2016-06-04/10-31-48-8169932_450_300.jpg', null, '2016-06-04 22:31:48');
INSERT INTO `image` VALUES ('93', '10-31-50-82700f5.jpg', '/Uploads/2016-06-04/10-31-50-82700f5.jpg', '/Uploads/2016-06-04/10-31-50-82700f5_450_300.jpg', null, '2016-06-04 22:31:50');
INSERT INTO `image` VALUES ('94', '10-31-51-7864ab2.jpg', '/Uploads/2016-06-04/10-31-51-7864ab2.jpg', '/Uploads/2016-06-04/10-31-51-7864ab2_450_300.jpg', null, '2016-06-04 22:31:51');
INSERT INTO `image` VALUES ('95', '10-35-44-138b392.jpg', '/Uploads/2016-06-04/10-35-44-138b392.jpg', '/Uploads/2016-06-04/10-35-44-138b392_450_300.jpg', null, '2016-06-04 22:35:44');
INSERT INTO `image` VALUES ('96', '10-35-44-9956ab9.jpg', '/Uploads/2016-06-04/10-35-44-9956ab9.jpg', '/Uploads/2016-06-04/10-35-44-9956ab9_450_300.jpg', null, '2016-06-04 22:35:44');
INSERT INTO `image` VALUES ('97', '10-35-46-968ff6b.jpg', '/Uploads/2016-06-04/10-35-46-968ff6b.jpg', '/Uploads/2016-06-04/10-35-46-968ff6b_450_300.jpg', null, '2016-06-04 22:35:46');
INSERT INTO `image` VALUES ('98', '10-35-47-160bb0e.jpg', '/Uploads/2016-06-04/10-35-47-160bb0e.jpg', '/Uploads/2016-06-04/10-35-47-160bb0e_450_300.jpg', null, '2016-06-04 22:35:47');
INSERT INTO `image` VALUES ('99', '10-43-11-519f38c.jpg', '/Uploads/2016-06-04/10-43-11-519f38c.jpg', '/Uploads/2016-06-04/10-43-11-519f38c_450_300.jpg', null, '2016-06-04 22:43:11');
INSERT INTO `image` VALUES ('100', '10-15-52-1108f4f.jpg', '/Uploads/2016-06-05/10-15-52-1108f4f.jpg', '/Uploads/2016-06-05/10-15-52-1108f4f_450_300.jpg', null, '2016-06-05 10:15:53');
INSERT INTO `image` VALUES ('101', '10-34-24-934e7ab.jpg', '/Uploads/2016-06-05/10-34-24-934e7ab.jpg', '/Uploads/2016-06-05/10-34-24-934e7ab_450_300.jpg', null, '2016-06-05 10:34:24');
INSERT INTO `image` VALUES ('102', '10-34-40-383b322.jpg', '/Uploads/2016-06-05/10-34-40-383b322.jpg', '/Uploads/2016-06-05/10-34-40-383b322_450_300.jpg', null, '2016-06-05 10:34:40');
INSERT INTO `image` VALUES ('103', '10-34-59-35b49e.jpg', '/Uploads/2016-06-05/10-34-59-35b49e.jpg', '/Uploads/2016-06-05/10-34-59-35b49e_450_300.jpg', null, '2016-06-05 10:34:59');
INSERT INTO `image` VALUES ('104', '11-52-46-4386f19.jpg', '/Uploads/2016-06-05/11-52-46-4386f19.jpg', '/Uploads/2016-06-05/11-52-46-4386f19_450_300.jpg', null, '2016-06-05 23:52:46');
INSERT INTO `image` VALUES ('105', '11-52-47-369e63d.jpg', '/Uploads/2016-06-05/11-52-47-369e63d.jpg', '/Uploads/2016-06-05/11-52-47-369e63d_450_300.jpg', null, '2016-06-05 23:52:47');
INSERT INTO `image` VALUES ('106', '11-52-47-4214a1f.jpg', '/Uploads/2016-06-05/11-52-47-4214a1f.jpg', '/Uploads/2016-06-05/11-52-47-4214a1f_450_300.jpg', null, '2016-06-05 23:52:47');
INSERT INTO `image` VALUES ('107', '11-52-47-31089c6.jpg', '/Uploads/2016-06-05/11-52-47-31089c6.jpg', '/Uploads/2016-06-05/11-52-47-31089c6_450_300.jpg', null, '2016-06-05 23:52:47');
INSERT INTO `image` VALUES ('108', '11-54-31-40367d2.jpg', '/Uploads/2016-06-05/11-54-31-40367d2.jpg', '/Uploads/2016-06-05/11-54-31-40367d2_450_300.jpg', null, '2016-06-05 23:54:31');
INSERT INTO `image` VALUES ('109', '11-54-31-45580f6.jpg', '/Uploads/2016-06-05/11-54-31-45580f6.jpg', '/Uploads/2016-06-05/11-54-31-45580f6_450_300.jpg', null, '2016-06-05 23:54:31');
INSERT INTO `image` VALUES ('110', '11-54-32-7031497.jpg', '/Uploads/2016-06-05/11-54-32-7031497.jpg', '/Uploads/2016-06-05/11-54-32-7031497_450_300.jpg', null, '2016-06-05 23:54:32');
INSERT INTO `image` VALUES ('111', '11-54-32-309fc0a.jpg', '/Uploads/2016-06-05/11-54-32-309fc0a.jpg', '/Uploads/2016-06-05/11-54-32-309fc0a_450_300.jpg', null, '2016-06-05 23:54:32');
INSERT INTO `image` VALUES ('112', '11-55-27-8094bd3.jpg', '/Uploads/2016-06-05/11-55-27-8094bd3.jpg', '/Uploads/2016-06-05/11-55-27-8094bd3_450_300.jpg', null, '2016-06-05 23:55:27');
INSERT INTO `image` VALUES ('113', '12-04-26-41399e1.jpg', '/Uploads/2016-06-06/12-04-26-41399e1.jpg', '/Uploads/2016-06-06/12-04-26-41399e1_450_300.jpg', null, '2016-06-06 00:04:26');
INSERT INTO `image` VALUES ('114', '12-04-26-106d581.jpg', '/Uploads/2016-06-06/12-04-26-106d581.jpg', '/Uploads/2016-06-06/12-04-26-106d581_450_300.jpg', null, '2016-06-06 00:04:26');
INSERT INTO `image` VALUES ('115', '12-04-26-9630fca.jpg', '/Uploads/2016-06-06/12-04-26-9630fca.jpg', '/Uploads/2016-06-06/12-04-26-9630fca_450_300.jpg', null, '2016-06-06 00:04:26');
INSERT INTO `image` VALUES ('116', '12-04-27-3748d14.jpg', '/Uploads/2016-06-06/12-04-27-3748d14.jpg', '/Uploads/2016-06-06/12-04-27-3748d14_450_300.jpg', null, '2016-06-06 00:04:27');
INSERT INTO `image` VALUES ('117', '12-04-27-58732fb.jpg', '/Uploads/2016-06-06/12-04-27-58732fb.jpg', '/Uploads/2016-06-06/12-04-27-58732fb_450_300.jpg', null, '2016-06-06 00:04:27');
INSERT INTO `image` VALUES ('118', '12-16-25-5178703.jpg', '/Uploads/2016-06-06/12-16-25-5178703.jpg', '/Uploads/2016-06-06/12-16-25-5178703_450_300.jpg', null, '2016-06-06 00:16:25');
INSERT INTO `image` VALUES ('119', '12-16-27-346e64a.jpg', '/Uploads/2016-06-06/12-16-27-346e64a.jpg', '/Uploads/2016-06-06/12-16-27-346e64a_450_300.jpg', null, '2016-06-06 00:16:27');
INSERT INTO `image` VALUES ('120', '12-16-28-967855.jpg', '/Uploads/2016-06-06/12-16-28-967855.jpg', '/Uploads/2016-06-06/12-16-28-967855_450_300.jpg', null, '2016-06-06 00:16:28');
INSERT INTO `image` VALUES ('121', '12-16-29-1668aed.jpg', '/Uploads/2016-06-06/12-16-29-1668aed.jpg', '/Uploads/2016-06-06/12-16-29-1668aed_450_300.jpg', null, '2016-06-06 00:16:29');

-- ----------------------------
-- Table structure for operate_log
-- ----------------------------
DROP TABLE IF EXISTS `operate_log`;
CREATE TABLE `operate_log` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `desript` varchar(200) DEFAULT NULL,
  `user_name` varchar(50) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `result` varchar(20) DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of operate_log
-- ----------------------------

-- ----------------------------
-- Table structure for page
-- ----------------------------
DROP TABLE IF EXISTS `page`;
CREATE TABLE `page` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `page_name` varchar(255) DEFAULT NULL,
  `page_title` varchar(255) DEFAULT NULL,
  `page_content` text,
  `update_time` datetime DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of page
-- ----------------------------
INSERT INTO `page` VALUES ('1', 'contact', 'tietle', 'conteetn', null, null);
INSERT INTO `page` VALUES ('2', 'our_company', 'asdfas', '<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; asdasdfasdf<img src=\"http://127.0.0.1:8888/uploads/2016-06-05/1cf13cc3-38df-4909-a437-0cc1245f619d.jpg\" _src=\"http://127.0.0.1:8888/uploads/2016-06-05/1cf13cc3-38df-4909-a437-0cc1245f619d.jpg\" width=\"575\" height=\"447\" style=\"width: 575px; height: 447px;\"/>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>', null, null);
INSERT INTO `page` VALUES ('3', 'terms_conditions', 'titel', 'dfjasf', null, null);
INSERT INTO `page` VALUES ('4', 'privacy', 'dfadf', 'sdfas', null, null);
INSERT INTO `page` VALUES ('8', '阿斯达顶', '阿斯达', '<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;贾克斯阿斯达 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>', null, null);

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_name` varchar(255) DEFAULT NULL,
  `product_desc` varchar(255) DEFAULT NULL,
  `country` varchar(255) DEFAULT NULL,
  `amazon_url` varchar(500) DEFAULT NULL,
  `main_image_id` int(11) DEFAULT NULL,
  `categoryid` int(11) DEFAULT NULL,
  `product_specification` text,
  `product_features` text,
  `seo_title` varchar(255) DEFAULT NULL,
  `seo_keyword` varchar(255) DEFAULT NULL,
  `seo_desc` varchar(255) DEFAULT NULL,
  `is_publish` int(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `categoryid` (`categoryid`),
  KEY `product_ibfk_1` (`main_image_id`),
  CONSTRAINT `product_ibfk_1` FOREIGN KEY (`main_image_id`) REFERENCES `image` (`id`) ON DELETE CASCADE,
  CONSTRAINT `product_ibfk_2` FOREIGN KEY (`categoryid`) REFERENCES `category` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of product
-- ----------------------------
INSERT INTO `product` VALUES ('2', 'asdasd', 'asdasd', null, 'asdas', '84', '1', '<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; asdasd &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>', '<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; asdasd &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>', 'dasd', 'asdasdas', 'dasdasd', '1');

-- ----------------------------
-- Table structure for setting
-- ----------------------------
DROP TABLE IF EXISTS `setting`;
CREATE TABLE `setting` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `value` longtext,
  `group` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of setting
-- ----------------------------
INSERT INTO `setting` VALUES ('1', 'title', 'asas', '网站标题');
INSERT INTO `setting` VALUES ('2', 'desc', 'hej sdfj asdf', '网站描述');
INSERT INTO `setting` VALUES ('3', 'keywords', 'asdad', '网站关键字');
INSERT INTO `setting` VALUES ('4', 'logo_path', '99', '网站LOGO');
INSERT INTO `setting` VALUES ('5', 'twitter_url', 'asd', '推特地址');
INSERT INTO `setting` VALUES ('6', 'facebook_url', 'asd', '脸书地址');
INSERT INTO `setting` VALUES ('7', 'google_plus_url', 'asd', '谷哥加地址');
INSERT INTO `setting` VALUES ('8', 'instagram_url', 'aasd', 'instagram地址');
INSERT INTO `setting` VALUES ('9', 'copy_right', 'is', '版权信息');
INSERT INTO `setting` VALUES ('10', 'play_images', '113,114,115,116|undefined1,undefined2,undefined3,undefined4', '首页播放图片');
INSERT INTO `setting` VALUES ('17', 'ani_code', 'code', '统计代码');
INSERT INTO `setting` VALUES ('18', 'main_four_product_ids', '1,2,3,4', '首页四图产品名称');

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) DEFAULT NULL,
  `password` varchar(124) DEFAULT NULL,
  `hash_code` varchar(20) DEFAULT NULL,
  `display_name` varchar(50) DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('1', 'admin', 'KeV6m9TkL9xHewfyL6Rr1jzuKPM=', null, null, null);

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(50) DEFAULT NULL,
  `real_name` varchar(50) DEFAULT NULL,
  `qq_number` varchar(20) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `mobile` varchar(20) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `photo_path` varchar(255) DEFAULT NULL,
  `password` varchar(124) DEFAULT NULL,
  `hash_code` varchar(20) DEFAULT NULL,
  `position_id` int(11) DEFAULT NULL COMMENT '字典表的ID',
  `is_admin` int(1) DEFAULT NULL,
  `company_id` int(11) DEFAULT NULL,
  `login_token` varchar(255) DEFAULT NULL,
  `last_login_time` datetime DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  `update_time` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `user_name` (`user_name`),
  KEY `company_id` (`company_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user
-- ----------------------------
