CREATE DATABASE  IF NOT EXISTS `warehouse` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `warehouse`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: warehouse
-- ------------------------------------------------------
-- Server version	8.0.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `authentications`
--

DROP TABLE IF EXISTS `authentications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `authentications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `auth_type` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authentications`
--

LOCK TABLES `authentications` WRITE;
/*!40000 ALTER TABLE `authentications` DISABLE KEYS */;
INSERT INTO `authentications` VALUES (1,'e3afed0047b08059d0fada10f400c1e5'),(2,'eb6d8ae6f20283755b339c0dc273988b'),(3,'62efb9ec331e364b96efe68c8b03ca20');
/*!40000 ALTER TABLE `authentications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expense_archives`
--

DROP TABLE IF EXISTS `expense_archives`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `expense_archives` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `revenue_amount` double NOT NULL DEFAULT '0',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_expense_archives_users` (`user_id`),
  CONSTRAINT `fk_expense_archives_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expense_archives`
--

LOCK TABLES `expense_archives` WRITE;
/*!40000 ALTER TABLE `expense_archives` DISABLE KEYS */;
INSERT INTO `expense_archives` VALUES (3,2,24524,'2018-05-11 08:50:35',1),(4,2,52,'2018-05-11 08:50:35',1),(5,2,215,'2018-05-11 08:50:35',1),(6,2,22.25,'2018-04-10 08:50:35',1),(7,2,25,'2018-05-14 08:51:38',1),(8,2,5000,'2018-05-22 08:52:01',1),(10,2,35,'2018-05-10 23:37:27',1),(11,2,100,'2018-05-11 01:16:34',1),(12,2,500,'2018-05-11 01:21:41',1),(13,2,35,'2018-05-11 01:38:06',1),(14,2,35,'2018-05-11 01:49:10',1),(17,2,35,'2018-05-10 23:37:27',1),(18,2,100,'2018-05-11 01:16:34',1),(19,2,500,'2018-05-11 01:21:41',1),(20,2,35,'2018-05-11 01:38:06',1),(21,2,35,'2018-05-11 01:49:10',1),(22,2,35,'2018-05-11 01:49:38',1),(24,2,2,'2018-05-12 08:06:37',1),(25,2,53,'2018-05-12 08:06:37',1);
/*!40000 ALTER TABLE `expense_archives` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `expense_archives_users_joined`
--

DROP TABLE IF EXISTS `expense_archives_users_joined`;
/*!50001 DROP VIEW IF EXISTS `expense_archives_users_joined`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `expense_archives_users_joined` AS SELECT 
 1 AS `id`,
 1 AS `user_id`,
 1 AS `revenue_amount`,
 1 AS `date`,
 1 AS `is_revised`,
 1 AS `username`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `expenses`
--

DROP TABLE IF EXISTS `expenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `expenses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `revenue_amount` double NOT NULL DEFAULT '0',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_expenses_users` (`user_id`),
  CONSTRAINT `fk_expenses_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expenses`
--

LOCK TABLES `expenses` WRITE;
/*!40000 ALTER TABLE `expenses` DISABLE KEYS */;
/*!40000 ALTER TABLE `expenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `expenses_users_joined`
--

DROP TABLE IF EXISTS `expenses_users_joined`;
/*!50001 DROP VIEW IF EXISTS `expenses_users_joined`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `expenses_users_joined` AS SELECT 
 1 AS `id`,
 1 AS `user_id`,
 1 AS `revenue_amount`,
 1 AS `date`,
 1 AS `is_revised`,
 1 AS `username`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `invoices`
--

DROP TABLE IF EXISTS `invoices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `invoices` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `revenue_amount` double NOT NULL DEFAULT '0',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_invoices_users` (`user_id`),
  CONSTRAINT `fk_invoices_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoices`
--

LOCK TABLES `invoices` WRITE;
/*!40000 ALTER TABLE `invoices` DISABLE KEYS */;
/*!40000 ALTER TABLE `invoices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `invoices_users_joined`
--

DROP TABLE IF EXISTS `invoices_users_joined`;
/*!50001 DROP VIEW IF EXISTS `invoices_users_joined`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `invoices_users_joined` AS SELECT 
 1 AS `id`,
 1 AS `user_id`,
 1 AS `revenue_amount`,
 1 AS `date`,
 1 AS `username`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `prod_cat_joined`
--

DROP TABLE IF EXISTS `prod_cat_joined`;
/*!50001 DROP VIEW IF EXISTS `prod_cat_joined`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `prod_cat_joined` AS SELECT 
 1 AS `id`,
 1 AS `category_id`,
 1 AS `product_name`,
 1 AS `quantity`,
 1 AS `import_price`,
 1 AS `sell_price`,
 1 AS `is_visible`,
 1 AS `category_name`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `product_categories`
--

DROP TABLE IF EXISTS `product_categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_categories` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `parent_id` int(11) NOT NULL DEFAULT '0',
  `category_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_categories`
--

LOCK TABLES `product_categories` WRITE;
/*!40000 ALTER TABLE `product_categories` DISABLE KEYS */;
INSERT INTO `product_categories` VALUES (1,0,'Main'),(2,1,'Coffe'),(3,0,'Напитки'),(4,0,'Храни'),(5,0,'Цигари'),(6,2,'Main');
/*!40000 ALTER TABLE `product_categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category_id` int(11) NOT NULL,
  `product_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `quantity` double NOT NULL DEFAULT '0',
  `import_price` double NOT NULL DEFAULT '0',
  `sell_price` double NOT NULL DEFAULT '0',
  `is_visible` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_category_id_id` (`category_id`),
  CONSTRAINT `fk_category_id_id` FOREIGN KEY (`category_id`) REFERENCES `product_categories` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,1,'Маргаритки',100,10,20,1),(2,1,'Salatki',100,0.4,1,1),(3,3,'Сандвич с риба тон',200,1,3,1),(4,1,'domatki',11,24.25,11.2,1),(5,2,'Nestle Coffe',12,1,11,1),(6,2,'Три в едно',11,1.1,253,1),(7,1,'Бисковитки',19,1,2,1),(8,2,'Бисковитки (редактирано)',200,1,2,1),(9,2,'Риба тон(Сандвич)',11,4,10,0),(10,1,'Бързата кафява лисица прескочи мъреливите куч',0,0,0,1),(11,1,'Вафла кредо',0,2,0,0),(12,4,'Хлеб',50,0.56,0.89,1),(13,4,'ЛЯБ',1,2,3,1),(14,1,'Козунак',10,22,43,0),(15,5,'Мелник',500,3,5,1),(16,1,'хх',0,0,0,1),(17,2,'Генади',0,15,50,1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products_transactions`
--

DROP TABLE IF EXISTS `products_transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products_transactions` (
  `product_id` int(11) NOT NULL,
  `transaction_id` int(11) NOT NULL,
  `product_quantity` double NOT NULL,
  PRIMARY KEY (`product_id`,`transaction_id`),
  KEY `fk_products_transactions_transactions` (`transaction_id`),
  CONSTRAINT `fk_products_transactions_products` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`),
  CONSTRAINT `fk_products_transactions_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products_transactions`
--

LOCK TABLES `products_transactions` WRITE;
/*!40000 ALTER TABLE `products_transactions` DISABLE KEYS */;
/*!40000 ALTER TABLE `products_transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `revenue_archives`
--

DROP TABLE IF EXISTS `revenue_archives`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `revenue_archives` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `revenue_amount` double NOT NULL DEFAULT '0',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_revenue_archives_users` (`user_id`),
  CONSTRAINT `fk_revenue_archives_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=136 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `revenue_archives`
--

LOCK TABLES `revenue_archives` WRITE;
/*!40000 ALTER TABLE `revenue_archives` DISABLE KEYS */;
INSERT INTO `revenue_archives` VALUES (1,2,3535,'2018-05-11 08:58:14',1),(2,2,200.22,'2018-05-11 09:02:25',1),(3,2,20034.22,'2018-05-11 09:05:25',1),(4,2,20034.22,'2018-05-11 09:05:39',1),(5,2,150,'2018-05-22 01:14:05',1),(6,2,34,'2018-05-11 01:16:06',1),(8,2,3535,'2018-05-11 08:58:14',1),(9,2,200.22,'2018-05-11 09:02:25',1),(10,2,20034.22,'2018-05-11 09:05:25',1),(11,2,20034.22,'2018-05-11 09:05:39',1),(12,2,150,'2018-05-22 01:14:05',1),(13,2,34,'2018-05-11 01:16:06',1),(14,2,35,'2018-05-03 01:16:06',1),(15,2,3535,'2018-05-11 08:58:14',1),(16,2,200.22,'2018-05-11 09:02:25',1),(17,2,20034.22,'2018-05-11 09:05:25',1),(18,2,20034.22,'2018-05-11 09:05:39',1),(19,2,150,'2018-05-22 01:14:05',1),(20,2,34,'2018-05-11 01:16:06',1),(21,2,35,'2018-05-03 01:16:06',1),(22,2,46,'2018-05-11 01:38:20',1),(30,2,3535,'2018-05-11 08:58:14',1),(31,2,200.22,'2018-05-11 09:02:25',1),(32,2,20034.22,'2018-05-11 09:05:25',1),(33,2,20034.22,'2018-05-11 09:05:39',1),(34,2,150,'2018-05-22 01:14:05',1),(35,2,34,'2018-05-11 01:16:06',1),(36,2,35,'2018-05-03 01:16:06',1),(37,2,46,'2018-05-11 01:38:20',1),(38,2,46,'2018-05-11 01:38:20',1),(45,2,3535,'2018-05-11 08:58:14',1),(46,2,200.22,'2018-05-11 09:02:25',1),(47,2,20034.22,'2018-05-11 09:05:25',1),(48,2,20034.22,'2018-05-11 09:05:39',1),(49,2,150,'2018-05-22 01:14:05',1),(50,2,34,'2018-05-11 01:16:06',1),(51,2,35,'2018-05-03 01:16:06',1),(52,2,46,'2018-05-11 01:38:20',1),(53,2,46,'2018-05-11 01:38:20',1),(54,2,34,'2018-05-11 01:38:20',1),(60,2,3535,'2018-05-11 08:58:14',1),(61,2,200.22,'2018-05-11 09:02:25',1),(62,2,20034.22,'2018-05-11 09:05:25',1),(63,2,20034.22,'2018-05-11 09:05:39',1),(64,2,150,'2018-05-22 01:14:05',1),(65,2,34,'2018-05-11 01:16:06',1),(66,2,35,'2018-05-03 01:16:06',1),(67,2,46,'2018-05-11 01:38:20',1),(68,2,46,'2018-05-11 01:38:20',1),(69,2,34,'2018-05-11 01:38:20',1),(70,2,36,'2018-05-11 01:38:20',1),(75,2,3535,'2018-05-11 08:58:14',1),(76,2,200.22,'2018-05-11 09:02:25',1),(77,2,20034.22,'2018-05-11 09:05:25',1),(78,2,20034.22,'2018-05-11 09:05:39',1),(79,2,150,'2018-05-22 01:14:05',1),(80,2,34,'2018-05-11 01:16:06',1),(81,2,35,'2018-05-03 01:16:06',1),(82,2,46,'2018-05-11 01:38:20',1),(83,2,46,'2018-05-11 01:38:20',1),(84,2,34,'2018-05-11 01:38:20',1),(85,2,36,'2018-05-11 01:38:20',1),(86,2,36,'2018-05-13 01:38:20',1),(90,2,3535,'2018-05-11 08:58:14',1),(91,2,200.22,'2018-05-11 09:02:25',1),(92,2,20034.22,'2018-05-11 09:05:25',1),(93,2,20034.22,'2018-05-11 09:05:39',1),(94,2,150,'2018-05-22 01:14:05',1),(95,2,34,'2018-05-11 01:16:06',1),(96,2,35,'2018-05-03 01:16:06',1),(97,2,46,'2018-05-11 01:38:20',1),(98,2,46,'2018-05-11 01:38:20',1),(99,2,34,'2018-05-11 01:38:20',1),(100,2,36,'2018-05-11 01:38:20',1),(101,2,36,'2018-05-13 01:38:20',1),(102,2,35,'2018-05-11 01:39:51',1),(105,2,3535,'2018-05-11 08:58:14',1),(106,2,200.22,'2018-05-11 09:02:25',1),(107,2,20034.22,'2018-05-11 09:05:25',1),(108,2,20034.22,'2018-05-11 09:05:39',1),(109,2,150,'2018-05-22 01:14:05',1),(110,2,34,'2018-05-11 01:16:06',1),(111,2,35,'2018-05-03 01:16:06',1),(112,2,46,'2018-05-11 01:38:20',1),(113,2,46,'2018-05-11 01:38:20',1),(114,2,34,'2018-05-11 01:38:20',1),(115,2,36,'2018-05-11 01:38:20',1),(116,2,36,'2018-05-13 01:38:20',1),(117,2,35,'2018-05-11 01:39:51',1),(118,2,35,'2018-05-11 01:45:23',1),(120,2,3535,'2018-05-11 08:58:14',1),(121,2,200.22,'2018-05-11 09:02:25',1),(122,2,20034.22,'2018-05-11 09:05:25',1),(123,2,20034.22,'2018-05-11 09:05:39',1),(124,2,150,'2018-05-22 01:14:05',1),(125,2,34,'2018-05-11 01:16:06',1),(126,2,35,'2018-05-03 01:16:06',1),(127,2,46,'2018-05-11 01:38:20',1),(128,2,46,'2018-05-11 01:38:20',1),(129,2,34,'2018-05-11 01:38:20',1),(130,2,36,'2018-05-11 01:38:20',1),(131,2,36,'2018-05-13 01:38:20',1),(132,2,35,'2018-05-11 01:39:51',1),(133,2,35,'2018-05-11 01:45:23',1),(134,2,3,'2018-05-11 01:46:25',1),(135,2,12345,'2018-05-11 01:46:25',1);
/*!40000 ALTER TABLE `revenue_archives` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `revenue_archives_users_joined`
--

DROP TABLE IF EXISTS `revenue_archives_users_joined`;
/*!50001 DROP VIEW IF EXISTS `revenue_archives_users_joined`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `revenue_archives_users_joined` AS SELECT 
 1 AS `id`,
 1 AS `user_id`,
 1 AS `revenue_amount`,
 1 AS `date`,
 1 AS `is_revised`,
 1 AS `username`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `revenues`
--

DROP TABLE IF EXISTS `revenues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `revenues` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `revenue_amount` double NOT NULL DEFAULT '0',
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_revenues_users` (`user_id`),
  CONSTRAINT `fk_revenues_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `revenues`
--

LOCK TABLES `revenues` WRITE;
/*!40000 ALTER TABLE `revenues` DISABLE KEYS */;
/*!40000 ALTER TABLE `revenues` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `revenues_users_joined`
--

DROP TABLE IF EXISTS `revenues_users_joined`;
/*!50001 DROP VIEW IF EXISTS `revenues_users_joined`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `revenues_users_joined` AS SELECT 
 1 AS `id`,
 1 AS `user_id`,
 1 AS `revenue_amount`,
 1 AS `date`,
 1 AS `is_revised`,
 1 AS `username`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `search_types`
--

DROP TABLE IF EXISTS `search_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `search_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `display_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `column_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `search_types`
--

LOCK TABLES `search_types` WRITE;
/*!40000 ALTER TABLE `search_types` DISABLE KEYS */;
INSERT INTO `search_types` VALUES (1,'Прод. име','product_name'),(2,'Категория','category_name'),(3,'Прод. Код','id');
/*!40000 ALTER TABLE `search_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transactions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `transaction_type` varchar(10) NOT NULL,
  `is_revised` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `tr_on_transactions_expenses_delete` BEFORE DELETE ON `transactions` FOR EACH ROW BEGIN
    DECLARE expense_id INT;
    SET expense_id = (SELECT te.expense_id FROM transactions_expenses AS te WHERE te.transaction_id = OLD.id LIMIT 1);
	DELETE FROM expenses WHERE id = expense_id;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `transactions_expenses`
--

DROP TABLE IF EXISTS `transactions_expenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transactions_expenses` (
  `transaction_id` int(11) NOT NULL,
  `expense_id` int(11) NOT NULL,
  PRIMARY KEY (`transaction_id`,`expense_id`),
  KEY `fk_transactions_expenses_expenses` (`expense_id`),
  CONSTRAINT `fk_transactions_expenses_expenses` FOREIGN KEY (`expense_id`) REFERENCES `expenses` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_transactions_expenses_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions_expenses`
--

LOCK TABLES `transactions_expenses` WRITE;
/*!40000 ALTER TABLE `transactions_expenses` DISABLE KEYS */;
/*!40000 ALTER TABLE `transactions_expenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions_revenues`
--

DROP TABLE IF EXISTS `transactions_revenues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transactions_revenues` (
  `transaction_id` int(11) NOT NULL,
  `revenue_id` int(11) NOT NULL,
  PRIMARY KEY (`transaction_id`,`revenue_id`),
  KEY `fk_transactions_revenues_revenues` (`revenue_id`),
  CONSTRAINT `fk_transactions_revenues_revenues` FOREIGN KEY (`revenue_id`) REFERENCES `revenues` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_transactions_revenues_transactions` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions_revenues`
--

LOCK TABLES `transactions_revenues` WRITE;
/*!40000 ALTER TABLE `transactions_revenues` DISABLE KEYS */;
/*!40000 ALTER TABLE `transactions_revenues` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `user_auth_joined`
--

DROP TABLE IF EXISTS `user_auth_joined`;
/*!50001 DROP VIEW IF EXISTS `user_auth_joined`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `user_auth_joined` AS SELECT 
 1 AS `id`,
 1 AS `username`,
 1 AS `password`,
 1 AS `auth_id`,
 1 AS `date_registered`,
 1 AS `auth_type`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `auth_id` int(11) NOT NULL,
  `date_registered` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `fk_auth_id_id` (`auth_id`),
  CONSTRAINT `fk_auth_id_id` FOREIGN KEY (`auth_id`) REFERENCES `authentications` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (2,'cyecize','0f4137ed1502b5045d6083aa258b5c42',1,'2018-04-20 18:11:55'),(3,'goran','e10adc3949ba59abbe56e057f20f883e',1,'2018-04-21 09:04:31'),(4,'worker','e10adc3949ba59abbe56e057f20f883e',3,'2018-04-21 09:25:48'),(5,'svetla','e10adc3949ba59abbe56e057f20f883e',2,'2018-04-21 09:26:07');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'warehouse'
--

--
-- Dumping routines for database 'warehouse'
--

--
-- Final view structure for view `expense_archives_users_joined`
--

/*!50001 DROP VIEW IF EXISTS `expense_archives_users_joined`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `expense_archives_users_joined` AS select `e`.`id` AS `id`,`e`.`user_id` AS `user_id`,`e`.`revenue_amount` AS `revenue_amount`,`e`.`date` AS `date`,`e`.`is_revised` AS `is_revised`,`u`.`username` AS `username` from (`expense_archives` `e` join `users` `u` on((`u`.`id` = `e`.`user_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `expenses_users_joined`
--

/*!50001 DROP VIEW IF EXISTS `expenses_users_joined`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `expenses_users_joined` AS select `e`.`id` AS `id`,`e`.`user_id` AS `user_id`,`e`.`revenue_amount` AS `revenue_amount`,`e`.`date` AS `date`,`e`.`is_revised` AS `is_revised`,`u`.`username` AS `username` from (`expenses` `e` join `users` `u` on((`u`.`id` = `e`.`user_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `invoices_users_joined`
--

/*!50001 DROP VIEW IF EXISTS `invoices_users_joined`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `invoices_users_joined` AS select `i`.`id` AS `id`,`i`.`user_id` AS `user_id`,`i`.`revenue_amount` AS `revenue_amount`,`i`.`date` AS `date`,`u`.`username` AS `username` from (`invoices` `i` join `users` `u` on((`u`.`id` = `i`.`user_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `prod_cat_joined`
--

/*!50001 DROP VIEW IF EXISTS `prod_cat_joined`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `prod_cat_joined` AS select `p`.`id` AS `id`,`p`.`category_id` AS `category_id`,`p`.`product_name` AS `product_name`,`p`.`quantity` AS `quantity`,`p`.`import_price` AS `import_price`,`p`.`sell_price` AS `sell_price`,`p`.`is_visible` AS `is_visible`,`pk`.`category_name` AS `category_name` from (`products` `p` join `product_categories` `pk` on((`p`.`category_id` = `pk`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `revenue_archives_users_joined`
--

/*!50001 DROP VIEW IF EXISTS `revenue_archives_users_joined`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `revenue_archives_users_joined` AS select `r`.`id` AS `id`,`r`.`user_id` AS `user_id`,`r`.`revenue_amount` AS `revenue_amount`,`r`.`date` AS `date`,`r`.`is_revised` AS `is_revised`,`u`.`username` AS `username` from (`revenue_archives` `r` join `users` `u` on((`u`.`id` = `r`.`user_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `revenues_users_joined`
--

/*!50001 DROP VIEW IF EXISTS `revenues_users_joined`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `revenues_users_joined` AS select `r`.`id` AS `id`,`r`.`user_id` AS `user_id`,`r`.`revenue_amount` AS `revenue_amount`,`r`.`date` AS `date`,`r`.`is_revised` AS `is_revised`,`u`.`username` AS `username` from (`revenues` `r` join `users` `u` on((`u`.`id` = `r`.`user_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `user_auth_joined`
--

/*!50001 DROP VIEW IF EXISTS `user_auth_joined`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `user_auth_joined` AS select `u`.`id` AS `id`,`u`.`username` AS `username`,`u`.`password` AS `password`,`u`.`auth_id` AS `auth_id`,`u`.`date_registered` AS `date_registered`,`a`.`auth_type` AS `auth_type` from (`users` `u` join `authentications` `a` on((`u`.`auth_id` = `a`.`id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-14 19:58:48
