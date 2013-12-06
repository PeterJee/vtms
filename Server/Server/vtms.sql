-- MySQL dump 10.13  Distrib 5.1.67, for Win64 (unknown)
--
-- Host: localhost    Database: vtms
-- ------------------------------------------------------
-- Server version	5.1.67-community

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
-- Create Database vtms
--
CREATE DATABASE vtms;
USE vtms;


--
-- Table structure for table `alters`
--

DROP TABLE IF EXISTS `alters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alters` (
  `serial` varchar(15) NOT NULL,
  `category` varchar(20) DEFAULT NULL,
  `license` varchar(10) DEFAULT NULL,
  `ownerName` varchar(100) DEFAULT NULL,
  `purpose` varchar(20) DEFAULT NULL,
  `owner` varchar(100) DEFAULT NULL,
  `newAddress` varchar(100) DEFAULT NULL,
  `postAddress` varchar(100) DEFAULT NULL,
  `postcode` varchar(10) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `mobile` varchar(20) DEFAULT NULL,
  `province` varchar(50) DEFAULT NULL,
  `department` varchar(50) DEFAULT NULL,
  `engine` bit(1) DEFAULT b'0',
  `body` bit(1) DEFAULT b'0',
  `color` bit(1) DEFAULT b'0',
  `whole` bit(1) DEFAULT b'0',
  `engineCode` bit(1) DEFAULT b'0',
  `vin` bit(1) DEFAULT b'0',
  `idCode` bit(1) DEFAULT b'0',
  `information` varchar(150) DEFAULT NULL,
  `agentName` varchar(100) DEFAULT NULL,
  `agentAddress` varchar(200) DEFAULT NULL,
  `agentPostcode` varchar(10) DEFAULT NULL,
  `agentPhone` varchar(20) DEFAULT NULL,
  `agentEmail` varchar(100) DEFAULT NULL,
  `handlerName` varchar(100) DEFAULT NULL,
  `handlerPhone` varchar(20) DEFAULT NULL,
  `saver` varchar(15) NOT NULL,
  `save_date` DATETIME NOT NULL,
  `printer` varchar(10) DEFAULT NULL,
  `print_date` DATETIME DEFAULT NULL,
  PRIMARY KEY (`serial`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alters`
--

LOCK TABLES `alters` WRITE;
/*!40000 ALTER TABLE `alters` DISABLE KEYS */;
/*!40000 ALTER TABLE `alters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `apply`
--

DROP TABLE IF EXISTS `apply`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `apply` (
  `serial` varchar(15) NOT NULL,
  `category` varchar(20) DEFAULT NULL,
  `license` varchar(10) DEFAULT NULL,
  `plateRenew` varchar(5) DEFAULT NULL,
  `plateChange` varchar(5) DEFAULT NULL,
  `driverRenew` varchar(5) DEFAULT NULL,
  `driverChange` varchar(50) DEFAULT NULL,
  `licenseApply` varchar(50) DEFAULT NULL,
  `licenseRenew` varchar(5) DEFAULT NULL,
  `licenseChange` varchar(50) DEFAULT NULL,
  `signApply` varchar(20) DEFAULT NULL,
  `signRenew` varchar(5) DEFAULT NULL,
  `signChange` varchar(50) DEFAULT NULL,
  `ownerName` varchar(100) DEFAULT NULL,
  `ownerAddress` varchar(200) DEFAULT NULL,
  `ownerPostcode` varchar(10) DEFAULT NULL,
  `ownerPhone` varchar(20) DEFAULT NULL,
  `ownerEmail` varchar(100) DEFAULT NULL,
  `ownerMobile` varchar(20) DEFAULT NULL,
  `agentName` varchar(100) DEFAULT NULL,
  `agentAddress` varchar(200) DEFAULT NULL,
  `agentPostcode` varchar(10) DEFAULT NULL,
  `agentPhone` varchar(20) DEFAULT NULL,
  `agentEmail` varchar(100) DEFAULT NULL,
  `handlerName` varchar(100) DEFAULT NULL,
  `handlerPhone` varchar(20) DEFAULT NULL,
  `saver` varchar(15) NOT NULL,
  `save_date` DATETIME NOT NULL,
  `printer` varchar(10) DEFAULT NULL,
  `print_date` DATETIME DEFAULT NULL,
  PRIMARY KEY (`serial`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `apply`
--

LOCK TABLES `apply` WRITE;
/*!40000 ALTER TABLE `apply` DISABLE KEYS */;
/*!40000 ALTER TABLE `apply` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `archives`
--

DROP TABLE IF EXISTS `archives`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `archives` (
  `license` varchar(5) NOT NULL,
  `process` varchar(5) DEFAULT NULL,
  `reason` varchar(100) DEFAULT NULL,
  `saveDate` datetime DEFAULT NULL,
  `saver` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`license`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `archives`
--

LOCK TABLES `archives` WRITE;
/*!40000 ALTER TABLE `archives` DISABLE KEYS */;
/*!40000 ALTER TABLE `archives` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `company` (
  `id` char(2) NOT NULL,
  `name` varchar(45) NOT NULL,
  `priority` int(11) NOT NULL DEFAULT '100',
  `isactive` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES ('00','友心',100,0x01);
INSERT INTO `company` VALUES ('01','鑫华',0,0x01);
INSERT INTO `company` VALUES ('02','金信',0,0x01);
INSERT INTO `company` VALUES ('03','宏达',0,0x01);
INSERT INTO `company` VALUES ('04','经涛',0,0x01);
INSERT INTO `company` VALUES ('05','诚信',0,0x01);
INSERT INTO `company` VALUES ('06','鸿运达',0,0x01);
INSERT INTO `company` VALUES ('07','经纬',0,0x01);
INSERT INTO `company` VALUES ('08','友邦帮卖',0,0x01);
INSERT INTO `company` VALUES ('09','速拍',0,0x01);
INSERT INTO `company` VALUES ('10','常客',0,0x01);
INSERT INTO `company` VALUES ('11','散客',0,0x01);
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `id` int auto_increment primary key,
  `userid` varchar(30) NOT NULL,
  `name` varchar(50) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `privilege`
--

DROP TABLE IF EXISTS `privilege`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `privilege` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` varchar(15) NOT NULL,
  `itmename` varchar(45) NOT NULL,
  `parentname` varchar(45) NOT NULL,
  `isactive` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `privilege`
--

LOCK TABLES `privilege` WRITE;
/*!40000 ALTER TABLE `privilege` DISABLE KEYS */;
/*!40000 ALTER TABLE `privilege` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `register`
--

DROP TABLE IF EXISTS `register`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `register` (
  `serial` varchar(15) NOT NULL,
  `category` varchar(20) DEFAULT NULL,
  `license` varchar(10) DEFAULT NULL,
  `apply` varchar(20) DEFAULT NULL,
  `revokereason` varchar(5) DEFAULT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `vin` varchar(17) DEFAULT NULL,
  `obtain` varchar(10) DEFAULT NULL,
  `purpose` varchar(10) DEFAULT NULL,
  `ownerName` varchar(100) DEFAULT NULL,
  `ownerAddress` varchar(200) DEFAULT NULL,
  `ownerPostcode` varchar(10) DEFAULT NULL,
  `ownerPhone` varchar(20) DEFAULT NULL,
  `ownerEmail` varchar(100) DEFAULT NULL,
  `ownerMobile` varchar(20) DEFAULT NULL,
  `province` varchar(15) DEFAULT NULL,
  `department` varchar(15) DEFAULT NULL,
  `agentName` varchar(100) DEFAULT NULL,
  `agentAddress` varchar(200) DEFAULT NULL,
  `agentPostcode` varchar(10) DEFAULT NULL,
  `agentPhone` varchar(20) DEFAULT NULL,
  `agentEmail` varchar(100) DEFAULT NULL,
  `handlerName` varchar(100) DEFAULT NULL,
  `handlerPhone` varchar(20) DEFAULT NULL,
  `saver` varchar(15) NOT NULL,
  `save_date` DATETIME NOT NULL,
  `printer` varchar(10) DEFAULT NULL,
  `print_date` DATETIME DEFAULT NULL,
  PRIMARY KEY (`serial`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `register`
--

LOCK TABLES `register` WRITE;
/*!40000 ALTER TABLE `register` DISABLE KEYS */;
/*!40000 ALTER TABLE `register` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `retrade`
--

DROP TABLE IF EXISTS `retrade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `retrade` (
  `serial` varchar(15) NOT NULL,
  `reserial` varchar(15) DEFAULT NULL,
  `originid` varchar(30) DEFAULT NULL,
  `originpic` mediumblob,
  `currentid` varchar(30) DEFAULT NULL,
  `currentpic` mediumblob,
  `license` char(5) DEFAULT NULL,
  `vin` varchar(20) DEFAULT NULL,
  `vehicletype` char(2) DEFAULT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `certificate` varchar(20) DEFAULT NULL,
  `register` char(6) DEFAULT NULL,
  `certification` char(8) DEFAULT NULL,
  `department` varchar(50) DEFAULT NULL,
  `company` varchar(50) DEFAULT NULL,
  `saver` varchar(15) DEFAULT NULL,
  `save_date` DATETIME DEFAULT NULL,
  `firstpic` mediumblob,
  `secondpic` mediumblob,
  `thirdpic` mediumblob,
  `forthpic` mediumblob,
  `istraded` bit(1) DEFAULT b'0',
  PRIMARY KEY (`serial`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `retrade`
--

LOCK TABLES `retrade` WRITE;
/*!40000 ALTER TABLE `retrade` DISABLE KEYS */;
/*!40000 ALTER TABLE `retrade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `depute`
--

DROP TABLE IF EXISTS `depute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `depute` (
  `serial` varchar(15) NOT NULL,
  `reserial` varchar(15) DEFAULT NULL,
  `originid` varchar(30) DEFAULT NULL,
  `originpic` mediumblob,
  `currentid` varchar(30) DEFAULT NULL,
  `currentpic` mediumblob,
  `license` char(5) DEFAULT NULL,
  `vin` varchar(20) DEFAULT NULL,
  `vehicletype` char(2) DEFAULT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `certificate` varchar(20) DEFAULT NULL,
  `register` char(6) DEFAULT NULL,
  `certification` char(8) DEFAULT NULL,
  `department` varchar(50) DEFAULT NULL,
  `company` varchar(50) DEFAULT NULL,
  `saver` varchar(15) DEFAULT NULL,
  `save_date` DATETIME DEFAULT NULL,
  `firstpic` mediumblob,
  `secondpic` mediumblob,
  `thirdpic` mediumblob,
  `forthpic` mediumblob,
  `istraded` bit(1) DEFAULT b'0',
  PRIMARY KEY (`serial`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `depute`
--

LOCK TABLES `depute` WRITE;
/*!40000 ALTER TABLE `depute` DISABLE KEYS */;
/*!40000 ALTER TABLE `depute` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` varchar(15) NOT NULL,
  `pwd` varchar(32) NOT NULL,
  `name` varchar(45) NOT NULL,
  `email` varchar(100) NOT NULL,
  `isactive` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('admin','21232F297A57A5A743894A0E4A801FC3','管理员','admin@host.com',0x01);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehicle`
--

DROP TABLE IF EXISTS `vehicle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vehicle` (
  `serial` varchar(15) NOT NULL,
  `originid` varchar(30) DEFAULT NULL,
  `originpic` mediumblob,
  `currentid` varchar(30) DEFAULT NULL,
  `currentpic` mediumblob,
  `invoice` varchar(20) DEFAULT NULL,
  `license` char(5) DEFAULT NULL,
  `vin` varchar(20) DEFAULT NULL,
  `vehicletype` char(2) DEFAULT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `certificate` varchar(20) DEFAULT NULL,
  `register` char(10) DEFAULT NULL,
  `certification` char(16) DEFAULT NULL,
  `actual` decimal(11) DEFAULT NULL,
  `transactions` decimal(11) DEFAULT NULL,
  `department` varchar(50) DEFAULT NULL,
  `company` varchar(50) DEFAULT NULL,
  `saver` varchar(15) DEFAULT NULL,
  `save_date` DATETIME DEFAULT '9999-12-31 23:59:59',
  `updater` varchar(15) DEFAULT NULL,
  `update_date` DATETIME DEFAULT '9999-12-31 23:59:59',
  `recorder` varchar(10) DEFAULT NULL,
  `record_date` DATETIME DEFAULT '9999-12-31 23:59:59',
  `isrecorded` bit(1) DEFAULT b'0',
  `charger` varchar(10) DEFAULT NULL,
  `charge_date` DATETIME DEFAULT '9999-12-31 23:59:59',
  `ischarged` bit(1) DEFAULT b'0',
  `printer` varchar(10) DEFAULT NULL,
  `print_date` DATETIME DEFAULT '9999-12-31 23:59:59',
  `isprinted` bit(1) DEFAULT b'0',
  `refunder` varchar(10) DEFAULT NULL,
  `refund_date` DATETIME DEFAULT '9999-12-31 23:59:59',
  `isrefund` bit(1) DEFAULT b'0',
  `granter` varchar(10) DEFAULT NULL,
  `grant_date` DATETIME DEFAULT '9999-12-31 23:59:59',
  `isgrant` bit(1) DEFAULT b'0',
  `firstpic` mediumblob,
  `secondpic` mediumblob,
  `thirdpic` mediumblob,
  `forthpic` mediumblob,
  PRIMARY KEY (`serial`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicle`
--

LOCK TABLES `vehicle` WRITE;
/*!40000 ALTER TABLE `vehicle` DISABLE KEYS */;
/*!40000 ALTER TABLE `vehicle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pic`
--

DROP TABLE IF EXISTS `pic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pic` (
  `serial` varchar(15) NOT NULL,
  `firstpic` mediumblob,
  `secondpic` mediumblob,
  `thirdpic` mediumblob,
  `forthpic` mediumblob,
  PRIMARY KEY (`serial`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vehicletype`
--

DROP TABLE IF EXISTS `vehicletype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vehicletype` (
  `id` char(2) NOT NULL,
  `name` varchar(45) NOT NULL,
  `priority` int(11) NOT NULL DEFAULT '100',
  `isactive` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicletype`
--

LOCK TABLES `vehicletype` WRITE;
/*!40000 ALTER TABLE `vehicletype` DISABLE KEYS */;
INSERT INTO `vehicletype` VALUES ('01','轿车',100,0x01);
INSERT INTO `vehicletype` VALUES ('02','客车（19座以下）',100,0x01);
INSERT INTO `vehicletype` VALUES ('03','客车（19座以上）',100,0x01);
INSERT INTO `vehicletype` VALUES ('04','小货车',100,0x01);
INSERT INTO `vehicletype` VALUES ('05','大货车（4.5吨以上）',100,0x01);
INSERT INTO `vehicletype` VALUES ('06','微型货车（1800kg以下）',100,0x01);
INSERT INTO `vehicletype` VALUES ('07','租赁',100,0x01);
INSERT INTO `vehicletype` VALUES ('08','出租营转非',100,0x01);
INSERT INTO `vehicletype` VALUES ('09','营转非',100,0x01);
INSERT INTO `vehicletype` VALUES ('10','越野车',100,0x01);
INSERT INTO `vehicletype` VALUES ('11','特种车',100,0x01);
INSERT INTO `vehicletype` VALUES ('12','出租车',100,0x01);
INSERT INTO `vehicletype` VALUES ('13','摩托车',100,0x01);
INSERT INTO `vehicletype` VALUES ('14','营运车',100,0x01);
INSERT INTO `vehicletype` VALUES ('15','大型车',100,0x01);
INSERT INTO `vehicletype` VALUES ('16','中型普通货车',100,0x01);
INSERT INTO `vehicletype` VALUES ('17','公路客运车转非营运',100,0x01);
INSERT INTO `vehicletype` VALUES ('18','中型厢式货车',100,0x01);
INSERT INTO `vehicletype` VALUES ('19','低速车',100,0x01);
INSERT INTO `vehicletype` VALUES ('20','教练汽车',100,0x01);
INSERT INTO `vehicletype` VALUES ('21','旅游客运',100,0x01);
INSERT INTO `vehicletype` VALUES ('22','公路客运',100,0x01);
INSERT INTO `vehicletype` VALUES ('23','公交客运',100,0x01);
/*!40000 ALTER TABLE `vehicletype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'vtms'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-03-12 16:56:27
