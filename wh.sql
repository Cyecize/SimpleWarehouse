-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: warehouse
-- ------------------------------------------------------
-- Server version	5.7.21-log

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
  `auth_type` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
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
  `category_name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
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
  `product_name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `quantity` double NOT NULL DEFAULT '0',
  `import_price` double NOT NULL DEFAULT '0',
  `sell_price` double NOT NULL DEFAULT '0',
  `is_visible` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_category_id_id` (`category_id`),
  CONSTRAINT `fk_category_id_id` FOREIGN KEY (`category_id`) REFERENCES `product_categories` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,1,'Маргаритки',100,10,20,1),(2,1,'Salatki',100,0.4,1,1),(3,3,'Сандвич с риба тон',200,1,3,1),(4,1,'domatki',11,24.25,11.2,1),(5,2,'Nestle Coffe',12,1,11,1),(6,2,'Три в едно',11,1,253,1),(7,1,'Бисковитки',19,1,2,1),(8,2,'Бисковитки (редактирано)',200,1,2,1),(9,2,'Риба тон(Сандвич)',11,4,10,0),(10,1,'Бързата кафява лисица прескочи мъреливите куч',0,0,0,1),(11,1,'Вафла кредо',0,2,0,0),(12,4,'Хлеб',0,0,0,1),(13,4,'ЛЯБ',1,2,3,1),(14,1,'Козунак',10,22,43,0),(15,5,'Мелник',500,3,5,1),(16,1,'хх',0,0,0,1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `search_types`
--

DROP TABLE IF EXISTS `search_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `search_types` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `display_name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `column_name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `search_types`
--

LOCK TABLES `search_types` WRITE;
/*!40000 ALTER TABLE `search_types` DISABLE KEYS */;
INSERT INTO `search_types` VALUES (1,'Прод. име','p.product_name'),(2,'Категория','pk.category_name'),(3,'Прод. Код','p.id');
/*!40000 ALTER TABLE `search_types` ENABLE KEYS */;
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
  `username` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
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
INSERT INTO `users` VALUES (2,'cyecize','0f4137ed1502b5045d6083aa258b5c42',1,'2018-04-20 21:11:55'),(3,'goran','e10adc3949ba59abbe56e057f20f883e',1,'2018-04-21 12:04:31'),(4,'worker','e10adc3949ba59abbe56e057f20f883e',3,'2018-04-21 12:25:48'),(5,'svetla','e10adc3949ba59abbe56e057f20f883e',2,'2018-04-21 12:26:07');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'warehouse'
--

--
-- Dumping routines for database 'warehouse'
--

--
-- Final view structure for view `prod_cat_joined`
--

/*!50001 DROP VIEW IF EXISTS `prod_cat_joined`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `prod_cat_joined` AS select `p`.`id` AS `id`,`p`.`category_id` AS `category_id`,`p`.`product_name` AS `product_name`,`p`.`quantity` AS `quantity`,`p`.`import_price` AS `import_price`,`p`.`sell_price` AS `sell_price`,`p`.`is_visible` AS `is_visible`,`pk`.`category_name` AS `category_name` from (`products` `p` join `product_categories` `pk` on((`p`.`category_id` = `pk`.`id`))) */;
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
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
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

-- Dump completed on 2018-04-27 15:34:30
