-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: tiemda
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


CREATE DATABASE Tiemda;
USE Tiemda;
--
-- Table structure for table `articulos`
--

DROP TABLE IF EXISTS `articulos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `articulos` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Tipo` enum('Hamburguesa','Pizza','Bebida') NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Costo` decimal(10,2) NOT NULL,
  `Descripccion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `articulos`
--

LOCK TABLES `articulos` WRITE;
/*!40000 ALTER TABLE `articulos` DISABLE KEYS */;
INSERT INTO `articulos` VALUES (1,'Hamburguesa','doble-c-queso',40.00,''),(2,'Hamburguesa','doble-c-queso-tocino',50.00,''),(3,'Hamburguesa','hawaiana',45.00,''),(4,'Hamburguesa','pollo-crujiente',35.00,''),(5,'Hamburguesa','queso-tocino',45.00,''),(6,'Hamburguesa','sencilla-c-queso',45.00,''),(7,'Pizza','antojo-especial',220.00,''),(8,'Pizza','carnes-frias',150.00,''),(9,'Pizza','hawaiana',155.00,''),(10,'Pizza','mexicana',185.00,''),(11,'Pizza','peperoni',140.00,''),(12,'Pizza','vegetariana',200.00,''),(13,'Bebida','agua-fresca',12.00,''),(14,'Bebida','cafe',15.00,''),(15,'Bebida','coca-cola',18.00,''),(16,'Bebida','frappe',35.00,''),(17,'Bebida','malteada',40.00,'');
/*!40000 ALTER TABLE `articulos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalles`
--

DROP TABLE IF EXISTS `detalles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalles` (
  `idVenta` int NOT NULL,
  `Producto` int NOT NULL,
  `Tipo` enum('Hamburguesa','Pizza','Bebida') NOT NULL,
  `Cantidad` int NOT NULL,
  `Total` decimal(10,2) NOT NULL,
  PRIMARY KEY (`idVenta`,`Producto`),
  KEY `idVenta_idx` (`idVenta`),
  KEY `Producto_idx` (`Producto`),
  CONSTRAINT `idVenta` FOREIGN KEY (`idVenta`) REFERENCES `ventas` (`idVentas`),
  CONSTRAINT `Producto` FOREIGN KEY (`Producto`) REFERENCES `articulos` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalles`
--

LOCK TABLES `detalles` WRITE;
/*!40000 ALTER TABLE `detalles` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `idUsuario` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Primer_Apellido` varchar(45) NOT NULL,
  `Segundo_Apellido` varchar(45) NOT NULL,
  `Contraseña` varchar(100) NOT NULL,
  `Correo` varchar(45) NOT NULL,
  `Tipo` varchar(45) NOT NULL,
  PRIMARY KEY (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'User','Lop','Zav','20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70','correo@gmail.com','1');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ventas` (
  `idVentas` int NOT NULL AUTO_INCREMENT,
  `fecha` varchar(45) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `Descripcion` varchar(255) NOT NULL,
  PRIMARY KEY (`idVentas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'tiemda'
--

--
-- Dumping routines for database 'tiemda'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-28 19:27:45
