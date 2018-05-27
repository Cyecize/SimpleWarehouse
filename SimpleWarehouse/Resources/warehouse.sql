-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 25, 2018 at 10:05 AM
-- Server version: 8.0.11
-- PHP Version: 7.2.4


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
  `auth_type` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `expenses`
--

DROP TABLE IF EXISTS `expenses`;
CREATE TABLE IF NOT EXISTS `expenses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `revenue_amount` double NOT NULL DEFAULT '0',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_expenses_users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Stand-in structure for view `expenses_users_joined`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `expenses_users_joined`;
CREATE TABLE IF NOT EXISTS `expenses_users_joined` (
`date` timestamp
,`id` int(11)
,`is_revised` tinyint(1)
,`revenue_amount` double
,`user_id` int(11)
,`username` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `invoices`
--

DROP TABLE IF EXISTS `invoices`;
CREATE TABLE IF NOT EXISTS `invoices` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `revenue_amount` double NOT NULL DEFAULT '0',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_invoices_users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Stand-in structure for view `invoices_users_joined`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `invoices_users_joined`;
CREATE TABLE IF NOT EXISTS `invoices_users_joined` (
`date` timestamp
,`id` int(11)
,`revenue_amount` double
,`user_id` int(11)
,`username` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category_id` int(11) NOT NULL,
  `product_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `quantity` double NOT NULL DEFAULT '0',
  `import_price` double NOT NULL DEFAULT '0',
  `sell_price` double NOT NULL DEFAULT '0',
  `is_visible` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_category_id_id` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `products_transactions`
--

DROP TABLE IF EXISTS `products_transactions`;
CREATE TABLE IF NOT EXISTS `products_transactions` (
  `product_id` int(11) NOT NULL,
  `transaction_id` int(11) NOT NULL,
  `product_quantity` double NOT NULL,
  PRIMARY KEY (`product_id`,`transaction_id`),
  KEY `fk_products_transactions_transactions` (`transaction_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `product_categories`
--

DROP TABLE IF EXISTS `product_categories`;
CREATE TABLE IF NOT EXISTS `product_categories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parent_id` int(11) NOT NULL DEFAULT '0',
  `category_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Stand-in structure for view `prod_cat_joined`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `prod_cat_joined`;
CREATE TABLE IF NOT EXISTS `prod_cat_joined` (
`category_id` int(11)
,`category_name` varchar(45)
,`id` int(11)
,`import_price` double
,`is_visible` tinyint(1)
,`product_name` varchar(45)
,`quantity` double
,`sell_price` double
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
  PRIMARY KEY (`id`),
  KEY `fk_revenues_users` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Stand-in structure for view `revenues_users_joined`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `revenues_users_joined`;
CREATE TABLE IF NOT EXISTS `revenues_users_joined` (
`date` timestamp
,`id` int(11)
,`is_revised` tinyint(1)
,`revenue_amount` double
,`user_id` int(11)
,`username` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `revisions`
--

DROP TABLE IF EXISTS `revisions`;
CREATE TABLE IF NOT EXISTS `revisions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `expenses` double NOT NULL,
  `revenue` double NOT NULL,
  `actual_revenue` double NOT NULL,
  `start_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `revision_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `search_types`
--

DROP TABLE IF EXISTS `search_types`;
CREATE TABLE IF NOT EXISTS `search_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `display_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `column_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE IF NOT EXISTS `transactions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `transaction_type` varchar(10) NOT NULL,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8;


-- --------------------------------------------------------

--
-- Table structure for table `transactions_expenses`
--

DROP TABLE IF EXISTS `transactions_expenses`;
CREATE TABLE IF NOT EXISTS `transactions_expenses` (
  `transaction_id` int(11) NOT NULL,
  `expense_id` int(11) NOT NULL,
  PRIMARY KEY (`transaction_id`,`expense_id`),
  KEY `fk_transactions_expenses_expenses` (`expense_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `transactions_revenues`
--

DROP TABLE IF EXISTS `transactions_revenues`;
CREATE TABLE IF NOT EXISTS `transactions_revenues` (
  `transaction_id` int(11) NOT NULL,
  `revenue_id` int(11) NOT NULL,
  PRIMARY KEY (`transaction_id`,`revenue_id`),
  KEY `fk_transactions_revenues_revenues` (`revenue_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `auth_id` int(11) NOT NULL,
  `date_registered` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `is_enabled` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_auth_id_id` (`auth_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Stand-in structure for view `user_auth_joined`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `user_auth_joined`;
CREATE VIEW `user_auth_joined`  AS  select `u`.`id` AS `id`,`u`.`auth_id` AS `auth_id`,`u`.`date_registered` AS `date_registered`,`u`.`is_enabled` AS `is_enabled`,`u`.`password` AS `password`,`u`.`username` AS `username`,`a`.`auth_type` AS `auth_type` from (`users` `u` join `authentications` `a` on((`a`.`id` = `u`.`auth_id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `expenses_users_joined`
--
DROP TABLE IF EXISTS `expenses_users_joined`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `expenses_users_joined`  AS  select `e`.`id` AS `id`,`e`.`user_id` AS `user_id`,`e`.`revenue_amount` AS `revenue_amount`,`e`.`date` AS `date`,`e`.`is_revised` AS `is_revised`,`u`.`username` AS `username` from (`expenses` `e` join `users` `u` on((`u`.`id` = `e`.`user_id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `invoices_users_joined`
--
DROP TABLE IF EXISTS `invoices_users_joined`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `invoices_users_joined`  AS  select `i`.`id` AS `id`,`i`.`user_id` AS `user_id`,`i`.`revenue_amount` AS `revenue_amount`,`i`.`date` AS `date`,`u`.`username` AS `username` from (`invoices` `i` join `users` `u` on((`u`.`id` = `i`.`user_id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `prod_cat_joined`
--
DROP TABLE IF EXISTS `prod_cat_joined`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `prod_cat_joined`  AS  select `p`.`id` AS `id`,`p`.`category_id` AS `category_id`,`p`.`product_name` AS `product_name`,`p`.`quantity` AS `quantity`,`p`.`import_price` AS `import_price`,`p`.`sell_price` AS `sell_price`,`p`.`is_visible` AS `is_visible`,`pk`.`category_name` AS `category_name` from (`products` `p` join `product_categories` `pk` on((`p`.`category_id` = `pk`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `revenues_users_joined`
--
DROP TABLE IF EXISTS `revenues_users_joined`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `revenues_users_joined`  AS  select `r`.`id` AS `id`,`r`.`user_id` AS `user_id`,`r`.`revenue_amount` AS `revenue_amount`,`r`.`date` AS `date`,`r`.`is_revised` AS `is_revised`,`u`.`username` AS `username` from (`revenues` `r` join `users` `u` on((`u`.`id` = `r`.`user_id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `user_auth_joined`
--

--
-- Constraints for dumped tables
--

--
-- Constraints for table `expenses`
--
ALTER TABLE `expenses`
  ADD CONSTRAINT `fk_expenses_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `invoices`
--
ALTER TABLE `invoices`
  ADD CONSTRAINT `fk_invoices_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_category_id_id` FOREIGN KEY (`category_id`) REFERENCES `product_categories` (`id`);

--
-- Constraints for table `products_transactions`
--
ALTER TABLE `products_transactions`
  ADD CONSTRAINT `fk_products_transactions_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `fk_products_transactions_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `revenues`
--
ALTER TABLE `revenues`
  ADD CONSTRAINT `fk_revenues_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `transactions_expenses`
--
ALTER TABLE `transactions_expenses`
  ADD CONSTRAINT `fk_transactions_expenses_expenses` FOREIGN KEY (`expense_id`) REFERENCES `expenses` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_transactions_expenses_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `transactions_revenues`
--
ALTER TABLE `transactions_revenues`
  ADD CONSTRAINT `fk_transactions_revenues_revenues` FOREIGN KEY (`revenue_id`) REFERENCES `revenues` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_transactions_revenues_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_auth_id_id` FOREIGN KEY (`auth_id`) REFERENCES `authentications` (`id`);


/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
