-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 07, 2018 at 02:25 PM
-- Server version: 5.7.21-log
-- PHP Version: 7.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `warehouse`
--

-- --------------------------------------------------------

--
-- Table structure for table `authentications`
--

DROP TABLE IF EXISTS `authentications`;
CREATE TABLE IF NOT EXISTS `authentications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `auth_type` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `authentications`
--

INSERT INTO `authentications` (`id`, `auth_type`) VALUES
(1, 'e3afed0047b08059d0fada10f400c1e5'),
(2, 'eb6d8ae6f20283755b339c0dc273988b'),
(3, '62efb9ec331e364b96efe68c8b03ca20');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category_id` int(11) NOT NULL,
  `product_name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `quantity` double NOT NULL DEFAULT '0',
  `import_price` double NOT NULL DEFAULT '0',
  `sell_price` double NOT NULL DEFAULT '0',
  `is_visible` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_category_id_id` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `category_id`, `product_name`, `quantity`, `import_price`, `sell_price`, `is_visible`) VALUES
(1, 1, 'Маргаритки', 100, 10, 20, 1),
(2, 1, 'Salatki', 100, 0.4, 1, 1),
(3, 3, 'Сандвич с риба тон', 200, 1, 3, 1),
(4, 1, 'domatki', 11, 24.25, 11.2, 1),
(5, 2, 'Nestle Coffe', 12, 1, 11, 1),
(6, 2, 'Три в едно', 11, 1, 253, 1),
(7, 1, 'Бисковитки', 19, 1, 2, 1),
(8, 2, 'Бисковитки (редактирано)', 200, 1, 2, 1),
(9, 2, 'Риба тон(Сандвич)', 11, 4, 10, 0),
(10, 1, 'Бързата кафява лисица прескочи мъреливите куч', 0, 0, 0, 1),
(11, 1, 'Вафла кредо', 0, 2, 0, 0),
(12, 4, 'Хлеб', 0, 0, 0, 1),
(13, 4, 'ЛЯБ', 1, 2, 3, 1),
(14, 1, 'Козунак', 10, 22, 43, 0),
(15, 5, 'Мелник', 500, 3, 5, 1),
(16, 1, 'хх', 0, 0, 0, 1),
(17, 6, 'Игнат(едитед)', 5003, 4003, 300, 0),
(18, 7, 'Вестник стандарт', 2, 1, 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `product_categories`
--

DROP TABLE IF EXISTS `product_categories`;
CREATE TABLE IF NOT EXISTS `product_categories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parent_id` int(11) NOT NULL DEFAULT '0',
  `category_name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `product_categories`
--

INSERT INTO `product_categories` (`id`, `parent_id`, `category_name`) VALUES
(1, 0, 'Main'),
(2, 1, 'Coffe'),
(3, 0, 'Напитки'),
(4, 0, 'Храни'),
(5, 0, 'Цигари'),
(6, 2, 'Main'),
(7, 0, 'Новини');

-- --------------------------------------------------------

--
-- Stand-in structure for view `prod_cat_joined`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `prod_cat_joined`;
CREATE TABLE IF NOT EXISTS `prod_cat_joined` (
`id` int(11)
,`category_id` int(11)
,`product_name` varchar(45)
,`quantity` double
,`import_price` double
,`sell_price` double
,`is_visible` tinyint(1)
,`category_name` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `revenues`
--

DROP TABLE IF EXISTS `revenues`;
CREATE TABLE IF NOT EXISTS `revenues` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `revenue_amount` double NOT NULL DEFAULT '0',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `search_types`
--

DROP TABLE IF EXISTS `search_types`;
CREATE TABLE IF NOT EXISTS `search_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `display_name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `column_name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `search_types`
--

INSERT INTO `search_types` (`id`, `display_name`, `column_name`) VALUES
(1, 'Прод. име', 'product_name'),
(2, 'Категория', 'category_name'),
(3, 'Прод. Код', 'id');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `auth_id` int(11) NOT NULL,
  `date_registered` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_auth_id_id` (`auth_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `auth_id`, `date_registered`) VALUES
(2, 'cyecize', '0f4137ed1502b5045d6083aa258b5c42', 1, '2018-04-20 21:11:55'),
(3, 'goran', 'e10adc3949ba59abbe56e057f20f883e', 1, '2018-04-21 12:04:31'),
(4, 'worker', 'e10adc3949ba59abbe56e057f20f883e', 3, '2018-04-21 12:25:48'),
(5, 'svetla', 'e10adc3949ba59abbe56e057f20f883e', 2, '2018-04-21 12:26:07');

-- --------------------------------------------------------

--
-- Stand-in structure for view `user_auth_joined`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `user_auth_joined`;
CREATE TABLE IF NOT EXISTS `user_auth_joined` (
`id` int(11)
,`username` varchar(45)
,`password` varchar(255)
,`auth_id` int(11)
,`date_registered` timestamp
,`auth_type` varchar(255)
);

-- --------------------------------------------------------

--
-- Structure for view `prod_cat_joined`
--
DROP TABLE IF EXISTS `prod_cat_joined`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `prod_cat_joined`  AS  select `p`.`id` AS `id`,`p`.`category_id` AS `category_id`,`p`.`product_name` AS `product_name`,`p`.`quantity` AS `quantity`,`p`.`import_price` AS `import_price`,`p`.`sell_price` AS `sell_price`,`p`.`is_visible` AS `is_visible`,`pk`.`category_name` AS `category_name` from (`products` `p` join `product_categories` `pk` on((`p`.`category_id` = `pk`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `user_auth_joined`
--
DROP TABLE IF EXISTS `user_auth_joined`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `user_auth_joined`  AS  select `u`.`id` AS `id`,`u`.`username` AS `username`,`u`.`password` AS `password`,`u`.`auth_id` AS `auth_id`,`u`.`date_registered` AS `date_registered`,`a`.`auth_type` AS `auth_type` from (`users` `u` join `authentications` `a` on((`u`.`auth_id` = `a`.`id`))) ;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_category_id_id` FOREIGN KEY (`category_id`) REFERENCES `product_categories` (`id`);

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_auth_id_id` FOREIGN KEY (`auth_id`) REFERENCES `authentications` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
