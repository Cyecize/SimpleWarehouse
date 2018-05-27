-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: 27 май 2018 в 22:11
-- Версия на сървъра: 8.0.11
-- PHP Version: 7.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `wh_warehouse`
--
CREATE DATABASE IF NOT EXISTS `wh_warehouse` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `wh_warehouse`;

-- --------------------------------------------------------

--
-- Структура на таблица `authentications`
--

DROP TABLE IF EXISTS `authentications`;
CREATE TABLE IF NOT EXISTS `authentications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `auth_type` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Схема на данните от таблица `authentications`
--

INSERT INTO `authentications` (`id`, `auth_type`) VALUES
(1, 'e3afed0047b08059d0fada10f400c1e5'),
(2, 'eb6d8ae6f20283755b339c0dc273988b'),
(3, '62efb9ec331e364b96efe68c8b03ca20');

-- --------------------------------------------------------

--
-- Структура на таблица `expenses`
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
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

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
-- Структура на таблица `invoices`
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
-- Структура на таблица `products`
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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `products_transactions`
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
-- Структура на таблица `product_categories`
--

DROP TABLE IF EXISTS `product_categories`;
CREATE TABLE IF NOT EXISTS `product_categories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parent_id` int(11) NOT NULL DEFAULT '0',
  `category_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

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
-- Структура на таблица `revenues`
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
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

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
-- Структура на таблица `revisions`
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура на таблица `search_types`
--

DROP TABLE IF EXISTS `search_types`;
CREATE TABLE IF NOT EXISTS `search_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `display_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `column_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Схема на данните от таблица `search_types`
--

INSERT INTO `search_types` (`id`, `display_name`, `column_name`) VALUES
(1, 'Прод. име', 'product_name'),
(2, 'Категория', 'category_name'),
(3, 'Прод. Код', 'id');

-- --------------------------------------------------------

--
-- Структура на таблица `transactions`
--

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE IF NOT EXISTS `transactions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `transaction_type` varchar(10) NOT NULL,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8;

--
-- Тригери `transactions`
--
DROP TRIGGER IF EXISTS `tr_on_transactions_expenses_delete`;
DELIMITER $$
CREATE TRIGGER `tr_on_transactions_expenses_delete` BEFORE DELETE ON `transactions` FOR EACH ROW BEGIN
    DECLARE expense_id INT;
    SET expense_id = (SELECT te.expense_id FROM transactions_expenses AS te WHERE te.transaction_id = OLD.id LIMIT 1);
	DELETE FROM expenses WHERE id = expense_id;
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `tr_on_transactions_revenues_delete`;
DELIMITER $$
CREATE TRIGGER `tr_on_transactions_revenues_delete` BEFORE DELETE ON `transactions` FOR EACH ROW BEGIN
	DECLARE rev_id INT;
    SET rev_id = (SELECT tr.revenue_id FROM transactions_revenues AS tr WHERE tr.transaction_id = OLD.id LIMIT 1);
    DELETE FROM revenues WHERE id = rev_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Структура на таблица `transactions_expenses`
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
-- Структура на таблица `transactions_revenues`
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
-- Структура на таблица `users`
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Stand-in structure for view `user_auth_joined`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `user_auth_joined`;
CREATE TABLE IF NOT EXISTS `user_auth_joined` (
`auth_id` int(11)
,`auth_type` varchar(255)
,`date_registered` timestamp
,`id` int(11)
,`is_enabled` tinyint(1)
,`password` varchar(255)
,`username` varchar(45)
);

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
DROP TABLE IF EXISTS `user_auth_joined`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `user_auth_joined`  AS  select `u`.`id` AS `id`,`u`.`auth_id` AS `auth_id`,`u`.`date_registered` AS `date_registered`,`u`.`is_enabled` AS `is_enabled`,`u`.`password` AS `password`,`u`.`username` AS `username`,`a`.`auth_type` AS `auth_type` from (`users` `u` join `authentications` `a` on((`a`.`id` = `u`.`auth_id`))) ;

--
-- Ограничения за дъмпнати таблици
--

--
-- Ограничения за таблица `expenses`
--
ALTER TABLE `expenses`
  ADD CONSTRAINT `fk_expenses_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Ограничения за таблица `invoices`
--
ALTER TABLE `invoices`
  ADD CONSTRAINT `fk_invoices_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Ограничения за таблица `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_category_id_id` FOREIGN KEY (`category_id`) REFERENCES `product_categories` (`id`);

--
-- Ограничения за таблица `products_transactions`
--
ALTER TABLE `products_transactions`
  ADD CONSTRAINT `fk_products_transactions_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `fk_products_transactions_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE;

--
-- Ограничения за таблица `revenues`
--
ALTER TABLE `revenues`
  ADD CONSTRAINT `fk_revenues_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Ограничения за таблица `transactions_expenses`
--
ALTER TABLE `transactions_expenses`
  ADD CONSTRAINT `fk_transactions_expenses_expenses` FOREIGN KEY (`expense_id`) REFERENCES `expenses` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_transactions_expenses_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE;

--
-- Ограничения за таблица `transactions_revenues`
--
ALTER TABLE `transactions_revenues`
  ADD CONSTRAINT `fk_transactions_revenues_revenues` FOREIGN KEY (`revenue_id`) REFERENCES `revenues` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `fk_transactions_revenues_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE;

--
-- Ограничения за таблица `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_auth_id_id` FOREIGN KEY (`auth_id`) REFERENCES `authentications` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
