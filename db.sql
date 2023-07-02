-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: school_mgmsys
-- ------------------------------------------------------
-- Server version	8.0.27

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

--
-- Table structure for table `dbo_absence`
--

DROP TABLE IF EXISTS `dbo_absence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_absence` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ClassbookId` int NOT NULL,
  `StudentId` int NOT NULL,
  `SubjectId` int NOT NULL,
  `Date` date NOT NULL,
  `WithLeave` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `fk_student_absence_idx` (`StudentId`),
  KEY `fk_subject_absence_idx` (`SubjectId`),
  KEY `fk_classbook_absence_idx` (`ClassbookId`),
  CONSTRAINT `fk_classbook_absence` FOREIGN KEY (`ClassbookId`) REFERENCES `dbo_classbook` (`Id`),
  CONSTRAINT `fk_student_absence` FOREIGN KEY (`StudentId`) REFERENCES `dbo_student` (`Id`),
  CONSTRAINT `fk_subject_absence` FOREIGN KEY (`SubjectId`) REFERENCES `dbo_subject` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_absence`
--

LOCK TABLES `dbo_absence` WRITE;
/*!40000 ALTER TABLE `dbo_absence` DISABLE KEYS */;
INSERT INTO `dbo_absence` VALUES (2,2,18,1,'2023-06-19',0),(3,2,18,1,'2023-06-12',0),(4,2,18,1,'2023-06-05',1);
/*!40000 ALTER TABLE `dbo_absence` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_class`
--

DROP TABLE IF EXISTS `dbo_class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_class` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SchoolId` int NOT NULL,
  `Name` varchar(15) NOT NULL,
  `ClassSpecializationId` int DEFAULT NULL,
  `HomeroomTeacherId` int DEFAULT NULL,
  `Year` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_school_class_idx` (`SchoolId`),
  KEY `fk_teacher_class_idx` (`HomeroomTeacherId`),
  KEY `fk_classspecialization_class_idx` (`ClassSpecializationId`),
  CONSTRAINT `fk_classspecialization_class` FOREIGN KEY (`ClassSpecializationId`) REFERENCES `dbo_classspecialization` (`Id`),
  CONSTRAINT `fk_school_class` FOREIGN KEY (`SchoolId`) REFERENCES `dbo_school` (`Id`),
  CONSTRAINT `fk_teacher_class` FOREIGN KEY (`HomeroomTeacherId`) REFERENCES `dbo_teacher` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_class`
--

LOCK TABLES `dbo_class` WRITE;
/*!40000 ALTER TABLE `dbo_class` DISABLE KEYS */;
INSERT INTO `dbo_class` VALUES (1,5,'8B',12,1,'2022-2023'),(5,5,'8A',12,1,'2022-2023'),(6,5,'8C',12,1,'2022-2023'),(7,5,'8D',12,1,'2022-2023'),(8,4,'9A',1,1,'2022-2023'),(9,4,'9B',1,1,'2022-2023'),(10,4,'9C',2,1,'2022-2023'),(11,4,'9D',2,1,'2022-2023'),(12,4,'9E',3,1,'2022-2023'),(13,4,'10A',1,1,'2022-2023'),(14,4,'10B',1,1,'2022-2023'),(15,4,'10C',2,1,'2022-2023'),(16,4,'10D',2,1,'2022-2023'),(17,4,'10E',3,1,'2022-2023'),(18,4,'11A',1,1,'2022-2023'),(19,4,'11B',1,1,'2022-2023'),(20,4,'11C',2,1,'2022-2023'),(21,4,'11D',2,1,'2022-2023'),(22,4,'11E',3,1,'2022-2023'),(23,4,'12A',1,1,'2022-2023'),(24,4,'12B',1,1,'2022-2023'),(25,4,'12C',2,1,'2022-2023'),(26,4,'12D',2,1,'2022-2023'),(27,4,'12E',3,1,'2022-2023');
/*!40000 ALTER TABLE `dbo_class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_classbook`
--

DROP TABLE IF EXISTS `dbo_classbook`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_classbook` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ClassId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_class_classbook_idx` (`ClassId`),
  CONSTRAINT `fk_class_classbook` FOREIGN KEY (`ClassId`) REFERENCES `dbo_class` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_classbook`
--

LOCK TABLES `dbo_classbook` WRITE;
/*!40000 ALTER TABLE `dbo_classbook` DISABLE KEYS */;
INSERT INTO `dbo_classbook` VALUES (1,1),(2,23),(3,24);
/*!40000 ALTER TABLE `dbo_classbook` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_classleader`
--

DROP TABLE IF EXISTS `dbo_classleader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_classleader` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ClassLeaderId` int NOT NULL,
  `ClassId` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `student_class_UNIQUE` (`ClassLeaderId`,`ClassId`),
  KEY `fk_class_classleader_idx` (`ClassId`),
  KEY `fk_student_classleader_idx` (`ClassLeaderId`),
  CONSTRAINT `fk_class_classleader` FOREIGN KEY (`ClassId`) REFERENCES `dbo_class` (`Id`),
  CONSTRAINT `fk_student_classleader` FOREIGN KEY (`ClassLeaderId`) REFERENCES `dbo_student` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_classleader`
--

LOCK TABLES `dbo_classleader` WRITE;
/*!40000 ALTER TABLE `dbo_classleader` DISABLE KEYS */;
INSERT INTO `dbo_classleader` VALUES (1,1,23);
/*!40000 ALTER TABLE `dbo_classleader` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_classspecialization`
--

DROP TABLE IF EXISTS `dbo_classspecialization`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_classspecialization` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_classspecialization`
--

LOCK TABLES `dbo_classspecialization` WRITE;
/*!40000 ALTER TABLE `dbo_classspecialization` DISABLE KEYS */;
INSERT INTO `dbo_classspecialization` VALUES (1,'Matematica-Informatica'),(2,'Biologie-Chimie'),(3,'Filologie'),(4,'Stiinte ale naturii'),(5,'Arte'),(6,'Sport'),(7,'Tehnic'),(8,'Pedagogic'),(9,'Economic'),(10,'Agricol'),(11,'Servicii'),(12,'Gimnazial');
/*!40000 ALTER TABLE `dbo_classspecialization` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_classsubject`
--

DROP TABLE IF EXISTS `dbo_classsubject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_classsubject` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ClassId` int NOT NULL,
  `SubjectId` int NOT NULL,
  `TeacherId` int NOT NULL,
  `WeeklyHours` int NOT NULL DEFAULT '0',
  `RequiredGrades` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `fk_class_classsubject_idx` (`ClassId`),
  KEY `fk_subject_classsubject_idx` (`SubjectId`),
  KEY `fk_teacher_classsubject_idx` (`TeacherId`),
  CONSTRAINT `fk_class_classsubject` FOREIGN KEY (`ClassId`) REFERENCES `dbo_class` (`Id`),
  CONSTRAINT `fk_subject_classsubject` FOREIGN KEY (`SubjectId`) REFERENCES `dbo_subject` (`Id`),
  CONSTRAINT `fk_teacher_classsubject` FOREIGN KEY (`TeacherId`) REFERENCES `dbo_teacher` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_classsubject`
--

LOCK TABLES `dbo_classsubject` WRITE;
/*!40000 ALTER TABLE `dbo_classsubject` DISABLE KEYS */;
INSERT INTO `dbo_classsubject` VALUES (1,23,1,1,0,5),(2,23,2,1,0,7),(3,24,2,1,0,7);
/*!40000 ALTER TABLE `dbo_classsubject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_grade`
--

DROP TABLE IF EXISTS `dbo_grade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_grade` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ClassbookId` int NOT NULL,
  `StudentId` int NOT NULL,
  `SubjectId` int NOT NULL,
  `Value` int NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_student_grade_idx` (`StudentId`),
  KEY `fk_subject_grade_idx` (`SubjectId`),
  KEY `fk_classbook_grade_idx` (`ClassbookId`),
  CONSTRAINT `fk_classbook_grade` FOREIGN KEY (`ClassbookId`) REFERENCES `dbo_classbook` (`Id`),
  CONSTRAINT `fk_student_grade` FOREIGN KEY (`StudentId`) REFERENCES `dbo_student` (`Id`),
  CONSTRAINT `fk_subject_grade` FOREIGN KEY (`SubjectId`) REFERENCES `dbo_subject` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_grade`
--

LOCK TABLES `dbo_grade` WRITE;
/*!40000 ALTER TABLE `dbo_grade` DISABLE KEYS */;
INSERT INTO `dbo_grade` VALUES (1,2,1,1,10,'2023-06-16'),(2,2,1,1,7,'2023-06-08'),(3,2,1,1,9,'2023-05-25'),(4,2,1,1,10,'2023-06-12'),(5,2,1,1,10,'2023-05-09'),(6,2,1,1,6,'2023-06-06'),(7,2,1,1,9,'2023-05-05'),(8,2,18,1,2,'2023-06-15'),(9,2,18,1,7,'2023-06-14');
/*!40000 ALTER TABLE `dbo_grade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_parentsinfo`
--

DROP TABLE IF EXISTS `dbo_parentsinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_parentsinfo` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `StudentId` int NOT NULL,
  `MotherFirstName` varchar(100) NOT NULL,
  `MotherLastName` varchar(100) NOT NULL,
  `MotherJob` varchar(100) NOT NULL,
  `MotherDateofBirth` date NOT NULL,
  `FatherFirstName` varchar(100) NOT NULL,
  `FatherLastName` varchar(100) NOT NULL,
  `FatherJob` varchar(100) NOT NULL,
  `FatherDateOfBirth` date NOT NULL,
  `MotherPhone` varchar(45) NOT NULL,
  `FatherPhone` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `StudentId_UNIQUE` (`StudentId`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  CONSTRAINT `fk_student_partentsinfo` FOREIGN KEY (`StudentId`) REFERENCES `dbo_student` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_parentsinfo`
--

LOCK TABLES `dbo_parentsinfo` WRITE;
/*!40000 ALTER TABLE `dbo_parentsinfo` DISABLE KEYS */;
INSERT INTO `dbo_parentsinfo` VALUES (1,1,'Adriana Eugenia','Andrica','Administrator','1979-07-01','Adrian Daniel','Andrica','Driver','1976-11-06','0765477108','0722536449');
/*!40000 ALTER TABLE `dbo_parentsinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_profilephotos`
--

DROP TABLE IF EXISTS `dbo_profilephotos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_profilephotos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `StudentId` int DEFAULT NULL,
  `TeacherId` int DEFAULT NULL,
  `UserId` int NOT NULL,
  `Photo` varchar(255) NOT NULL DEFAULT 'http://localhost:8887/photos/defaultProfilePicture.png',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `UserId_UNIQUE` (`UserId`),
  UNIQUE KEY `StudentId_UNIQUE` (`StudentId`),
  UNIQUE KEY `TeacherId_UNIQUE` (`TeacherId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_profilephotos`
--

LOCK TABLES `dbo_profilephotos` WRITE;
/*!40000 ALTER TABLE `dbo_profilephotos` DISABLE KEYS */;
INSERT INTO `dbo_profilephotos` VALUES (1,NULL,1,4,'http://192.168.1.3:8887/photos/defaultProfilePicture.png'),(2,1,NULL,2,'http://192.168.1.3:8887/photos/IMG_20221021_233821_688.jpg');
/*!40000 ALTER TABLE `dbo_profilephotos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_role`
--

DROP TABLE IF EXISTS `dbo_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_role` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_role`
--

LOCK TABLES `dbo_role` WRITE;
/*!40000 ALTER TABLE `dbo_role` DISABLE KEYS */;
INSERT INTO `dbo_role` VALUES (1,'Student'),(2,'Teacher'),(3,'Admin'),(4,'Director');
/*!40000 ALTER TABLE `dbo_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_school`
--

DROP TABLE IF EXISTS `dbo_school`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_school` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_school`
--

LOCK TABLES `dbo_school` WRITE;
/*!40000 ALTER TABLE `dbo_school` DISABLE KEYS */;
INSERT INTO `dbo_school` VALUES (3,'Colegiul National Mihai Eminescu'),(4,'Liceul Teoretic Aurel Vlaicu'),(5,'Scoala Generala Dominic Stanca'),(6,'Colegiul National Decebal');
/*!40000 ALTER TABLE `dbo_school` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_schoolprincipal`
--

DROP TABLE IF EXISTS `dbo_schoolprincipal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_schoolprincipal` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SchoolId` int NOT NULL,
  `PrincipalId` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `SchoolId_UNIQUE` (`SchoolId`),
  UNIQUE KEY `PrincipalId_UNIQUE` (`PrincipalId`),
  CONSTRAINT `fk_school_schoolprincipal` FOREIGN KEY (`SchoolId`) REFERENCES `dbo_school` (`Id`),
  CONSTRAINT `fk_teacher_schoolprincipal` FOREIGN KEY (`PrincipalId`) REFERENCES `dbo_teacher` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_schoolprincipal`
--

LOCK TABLES `dbo_schoolprincipal` WRITE;
/*!40000 ALTER TABLE `dbo_schoolprincipal` DISABLE KEYS */;
/*!40000 ALTER TABLE `dbo_schoolprincipal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_schoolteacher`
--

DROP TABLE IF EXISTS `dbo_schoolteacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_schoolteacher` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SchoolId` int NOT NULL,
  `TeacherId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_school_map_idx` (`SchoolId`),
  KEY `fk_teacher_map2_idx` (`TeacherId`),
  CONSTRAINT `fk_school_map` FOREIGN KEY (`SchoolId`) REFERENCES `dbo_school` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `fk_teacher_map2` FOREIGN KEY (`TeacherId`) REFERENCES `dbo_teacher` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_schoolteacher`
--

LOCK TABLES `dbo_schoolteacher` WRITE;
/*!40000 ALTER TABLE `dbo_schoolteacher` DISABLE KEYS */;
INSERT INTO `dbo_schoolteacher` VALUES (1,4,1);
/*!40000 ALTER TABLE `dbo_schoolteacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_schoolyear`
--

DROP TABLE IF EXISTS `dbo_schoolyear`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_schoolyear` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `StartYear` int NOT NULL,
  `EndYear` int NOT NULL,
  `IsClosed` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_schoolyear`
--

LOCK TABLES `dbo_schoolyear` WRITE;
/*!40000 ALTER TABLE `dbo_schoolyear` DISABLE KEYS */;
/*!40000 ALTER TABLE `dbo_schoolyear` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_session`
--

DROP TABLE IF EXISTS `dbo_session`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_session` (
  `Id` varchar(255) NOT NULL,
  `Token` varchar(500) NOT NULL,
  `UserId` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  UNIQUE KEY `Token_UNIQUE` (`Token`),
  KEY `fk_user_session_idx` (`UserId`),
  CONSTRAINT `fk_user_session` FOREIGN KEY (`UserId`) REFERENCES `dbo_user` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_session`
--

LOCK TABLES `dbo_session` WRITE;
/*!40000 ALTER TABLE `dbo_session` DISABLE KEYS */;
INSERT INTO `dbo_session` VALUES ('/hbe0U3nxwfks4DKKs+SPN4p72ohNUcsEWS7+JnIccI','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg3MDMwNDczLCJleHAiOjE2ODcwMzQwNzMsImlhdCI6MTY4NzAzMDQ3MywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.MEUZDVNGIpEJTntjaRFhK1cuSSTtuMIu6ICk7Q2a8ZI',4),('+jCyRFhh6YAJIBWuY1F/W9J9aAKdhJO2ROWXHswsnCg','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2OTQyNDgzLCJleHAiOjE2ODY5NDYwODMsImlhdCI6MTY4Njk0MjQ4MywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.OKJLa1XfhfLQVEAfu0NIZ63mkjG58NkJlRSWWnYD3h8',4),('0rqn2pDITuqzKmO8YRsyynCUCZXxyIY0zzORNzBFqE8','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkZWxpbmFuZHJpY2EiLCJyb2xlIjoiU3R1ZGVudCIsIm5iZiI6MTY4NzE4MjkwMiwiZXhwIjoxNjg3MTg2NTAyLCJpYXQiOjE2ODcxODI5MDIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODA4MCJ9.LXmjnqy_ehyoCO7d8zLvbxghQAGLPFa_kQpVDTezdlE',2),('6Xe5UIaijkgyoxz8InSh+N2WDfyIAByJY0kqn1ZJw8I','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg3MDIzMDU4LCJleHAiOjE2ODcwMjY2NTgsImlhdCI6MTY4NzAyMzA1OCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.sG6MRLpjN-u4QH5M1BiEJCmEwlHjkmIxiJOTDeaFWnQ',4),('84ITDfCRwuAqMmdqQH6NAMsqkq/sWhZa3Bjh/8bhMrI','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2ODIzODYxLCJleHAiOjE2ODY4Mjc0NjEsImlhdCI6MTY4NjgyMzg2MSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.RGOEGbJ1aHnuZR3NCZ4C4WEYu9ZA0wWM0ZNFAv3aKdE',4),('9/VtL1JNV83HA3G1RSKcmw04a5eytCaTQiICHII9/OI','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2ODIzODgwLCJleHAiOjE2ODY4Mjc0ODAsImlhdCI6MTY4NjgyMzg4MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.ZPJJy3F6WEpd5jiDobBSNBxGmL0RejpNzyWrJXKhXN8',4),('aNezg7n5ZeNwhQXZVw3W0eEJDUGhrdzzfOgSWeZRjko','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2ODQ1NTMwLCJleHAiOjE2ODY4NDkxMzAsImlhdCI6MTY4Njg0NTUzMCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.9Ok6QF8xugaKMUh_Znyj2J28NfU3GBH8bPmILsgmUeE',4),('ASVepd64YqyPgbtoYTyx+c070YlqOlEvMYXOp9tKsMo','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg3MDkyMzc1LCJleHAiOjE2ODcwOTU5NzUsImlhdCI6MTY4NzA5MjM3NSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.drDJbOCP2E8CChXJPgrsrXoM8UdVPKyMKSysgOlCx2o',4),('fLIo8w25isy94E9XiO17nR3VWoxJpYyLwBC79hXuvyE','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2NjcyMDA1LCJleHAiOjE2ODY2NzU2MDUsImlhdCI6MTY4NjY3MjAwNSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.3pBu_5wCvY-2A6gVeGaA-rlBqJDhI2Pg3UcgSHcYWiY',4),('GF5UFOOXTrbwt0qQzaJjXXfbrWj7zkNaLo7g7YTOZLc','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg3MDg1NjkwLCJleHAiOjE2ODcwODkyOTAsImlhdCI6MTY4NzA4NTY5MCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.aUKmNEVSLnSUiPNSGHc-3bHogvk5MjuNkVTRoY1eQGg',4),('hBPoMaISENCthf8L506ZpFYl7ydVvsARAc+Y4YoLh+E','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2NzQxNTg4LCJleHAiOjE2ODY3NDUxODgsImlhdCI6MTY4Njc0MTU4OCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.Cr8zumo8Xud_BnIujyU9kgUWf_xtYNQP8Kp0JvWRLoo',4),('HKmqQU9mZNv472WsoyGWPT7qSrlFTR8dKywABw/sbrE','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2NzQ4Nzg0LCJleHAiOjE2ODY3NTIzODQsImlhdCI6MTY4Njc0ODc4NCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0._K62JAwSftloSlRyhn7AGL_eZIxMtR6EUShCI6s1fQE',4),('jJBbvfcx50nKC5N0OhmJY5SEPALJaFtAXw0uM92alh4','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2ODMyMDg4LCJleHAiOjE2ODY4MzU2ODgsImlhdCI6MTY4NjgzMjA4OCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.LDKi3Cilw67NC_dzaaPi8rYGzxEjBQMUmqK0Ngrc9QU',4),('kg7u4wbLb/L0uitTOdgnaYdtiV8pyF3y3CP6kdZdnU8','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2OTIwOTI5LCJleHAiOjE2ODY5MjQ1MjksImlhdCI6MTY4NjkyMDkyOSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.Bd1-asXHFAwjovWrW3J2wJAWBC9_x2lq2JvclYN7_tE',4),('lY7W+BC0MB1SL0qtFzhhtoqQDgGG9RFyG0E2vL7t4uY','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2ODUyNzExLCJleHAiOjE2ODY4NTYzMTEsImlhdCI6MTY4Njg1MjcxMSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.C41MljTOpuNHZM2EYWgiPBIeYVWYa19JZ0--4VvDgso',4),('mFDcLn62lrnQnYHh0XaksvILTuoW1xVN7GyYEIbBBlU','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2NzU1NDE5LCJleHAiOjE2ODY3NTkwMTksImlhdCI6MTY4Njc1NTQxOSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.ouylgen7DEbjCXxLfjTZGkH3U5e5ZlbR6_3y6hxjPCE',4),('pQe/li/YRnET6dxBj9LbVC3C4X/8zr+mmHUw9RgBv2o','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkZWxpbmFuZHJpY2EiLCJyb2xlIjoiU3R1ZGVudCIsIm5iZiI6MTY4NjU3ODEyNywiZXhwIjoxNjg2NTgxNzI3LCJpYXQiOjE2ODY1NzgxMjcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODA4MCJ9.2V8U74PssBrCLOeMlLX2-CXDS6G_rCaSPkcFQqcjEEY',2),('qYkDUI3YWzgsXz1190GcmmiwHpHBR73S7ULOrH/DDqM','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkZWxpbmFuZHJpY2EiLCJyb2xlIjoiU3R1ZGVudCIsIm5iZiI6MTY4NjU5MjcxMCwiZXhwIjoxNjg2NTk2MzEwLCJpYXQiOjE2ODY1OTI3MTAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODA4MCJ9.Gn5XZRrv1DBWfGlXfhHK-QSbX4dmUc4o4PWo-tNG3WM',2),('rwHALq+YK7QnHZ6pSndAAMAFb5O1FQNpQIvKPoOVg40','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkZWxpbmFuZHJpY2EiLCJyb2xlIjoiU3R1ZGVudCIsIm5iZiI6MTY4NjgyMzg1OCwiZXhwIjoxNjg2ODI3NDU4LCJpYXQiOjE2ODY4MjM4NTgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODA4MCJ9.w8OrBJGlVKlvy5TLiDpPf99-JAYWlv1tQZIoSWDDMps',2),('Vk7bpsAOuZl8X03eFCtCUsCCwI10JBRhVumkdE3ubrE','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg3MDI2Njg2LCJleHAiOjE2ODcwMzAyODYsImlhdCI6MTY4NzAyNjY4NiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.JV0VreEKTPIyAOK21r4fDdkv0-VebzudhFwM4b7Ulns',4),('wbfXqhrB3uI5NBtZ+dtZOowhpbVWwYgGFFRpwVHOdlE','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVtaWxpYW5jZXVjYSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNjg2ODU2MzIwLCJleHAiOjE2ODY4NTk5MjAsImlhdCI6MTY4Njg1NjMyMCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo4MDgwIn0.zQKprOAcgtgs_YoG4tYGBrkjRKqA5XuiRRPz1ZLEKrQ',4),('Z03m6YnCYa5KsrJpjESi4J22wHnUKsv3p/fdhlMRY40','eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkZWxpbmFuZHJpY2EiLCJyb2xlIjoiU3R1ZGVudCIsIm5iZiI6MTY4NjU4NDczMSwiZXhwIjoxNjg2NTg4MzMxLCJpYXQiOjE2ODY1ODQ3MzEsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODA4MCJ9.fnNC0HwrPRoJ9Ohlv0vuYjpgdbM0Gsg0AgwFNvKAkzM',2);
/*!40000 ALTER TABLE `dbo_session` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_situations`
--

DROP TABLE IF EXISTS `dbo_situations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_situations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `StudentId` int NOT NULL,
  `ClassbookId` int NOT NULL,
  `SubjectId` int NOT NULL,
  `Value` int NOT NULL,
  `IsGeneralAverage` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_student_situations_idx` (`StudentId`),
  KEY `fk_subject_situations_idx` (`SubjectId`),
  KEY `fk_classbook_situations_idx` (`ClassbookId`),
  CONSTRAINT `fk_classbook_situations` FOREIGN KEY (`ClassbookId`) REFERENCES `dbo_classbook` (`Id`),
  CONSTRAINT `fk_student_situations` FOREIGN KEY (`StudentId`) REFERENCES `dbo_student` (`Id`),
  CONSTRAINT `fk_subject_situations` FOREIGN KEY (`SubjectId`) REFERENCES `dbo_subject` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_situations`
--

LOCK TABLES `dbo_situations` WRITE;
/*!40000 ALTER TABLE `dbo_situations` DISABLE KEYS */;
INSERT INTO `dbo_situations` VALUES (1,1,2,1,9,0);
/*!40000 ALTER TABLE `dbo_situations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_student`
--

DROP TABLE IF EXISTS `dbo_student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_student` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `SchoolId` int NOT NULL,
  `ClassId` int NOT NULL,
  `Photo` varchar(255) NOT NULL DEFAULT 'http://localhost:8887/photos/defaultProfilePicture.png',
  `UserId` int DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_school_student_idx` (`SchoolId`),
  KEY `fk_user_student_idx` (`UserId`),
  KEY `fk_class_student_idx` (`ClassId`),
  CONSTRAINT `fk_class_student` FOREIGN KEY (`ClassId`) REFERENCES `dbo_class` (`Id`),
  CONSTRAINT `fk_school_student` FOREIGN KEY (`SchoolId`) REFERENCES `dbo_school` (`Id`),
  CONSTRAINT `fk_user_student` FOREIGN KEY (`UserId`) REFERENCES `dbo_user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_student`
--

LOCK TABLES `dbo_student` WRITE;
/*!40000 ALTER TABLE `dbo_student` DISABLE KEYS */;
INSERT INTO `dbo_student` VALUES (1,'Adelin','Andrica','Eroilor 37/17, Scara B, Etaj 3, Orastie 335700, HD',4,23,'http://192.168.1.2:8887/photos/IMG_20221021_233821_688.jpg',2,'2000-10-13'),(2,'Ioan','Cutean','Alba Iulia pe bulevard ca jmekerii',5,5,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',3,'2001-01-29'),(17,'John','Smith','1234 Example St, City, State, ZIP',4,22,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(18,'Jane','Johnson','1234 Example St, City, State, ZIP',4,23,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(19,'Michael','Brown','1234 Example St, City, State, ZIP',4,25,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(20,'Michael','Johnson','1234 Example St, City, State, ZIP',4,17,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(21,'John','Brown','1234 Example St, City, State, ZIP',4,24,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(22,'Michael','Lee','1234 Example St, City, State, ZIP',4,13,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(23,'Michael','Brown','1234 Example St, City, State, ZIP',4,21,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(24,'Jane','Johnson','1234 Example St, City, State, ZIP',4,25,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(25,'Emma','Taylor','1234 Example St, City, State, ZIP',4,27,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(26,'Emma','Taylor','1234 Example St, City, State, ZIP',4,21,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(27,'Sophia','Lee','1234 Example St, City, State, ZIP',4,25,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(28,'Jane','Johnson','1234 Example St, City, State, ZIP',4,9,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(29,'John','Taylor','1234 Example St, City, State, ZIP',4,21,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(30,'Emma','Johnson','1234 Example St, City, State, ZIP',4,27,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(31,'Sophia','Smith','1234 Example St, City, State, ZIP',4,16,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(32,'John','Doe','1234 Example St, City, State, ZIP',4,25,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(33,'Sophia','Brown','1234 Example St, City, State, ZIP',4,15,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(34,'Jane','Doe','1234 Example St, City, State, ZIP',4,27,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(35,'David','Brown','1234 Example St, City, State, ZIP',4,9,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(36,'David','Brown','1234 Example St, City, State, ZIP',4,27,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(37,'David','Smith','1234 Example St, City, State, ZIP',4,10,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(38,'David','Lee','1234 Example St, City, State, ZIP',4,21,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(39,'Sophia','Doe','1234 Example St, City, State, ZIP',4,25,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(40,'Jane','Brown','1234 Example St, City, State, ZIP',4,13,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(41,'Emma','Doe','1234 Example St, City, State, ZIP',4,21,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(42,'Jane','Doe','1234 Example St, City, State, ZIP',4,19,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(43,'John','Smith','1234 Example St, City, State, ZIP',4,23,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(44,'Jane','Brown','1234 Example St, City, State, ZIP',4,14,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(45,'David','Brown','1234 Example St, City, State, ZIP',4,16,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10'),(46,'Michael','Brown','1234 Example St, City, State, ZIP',4,13,'http://192.168.1.2:8887/photos/defaultProfilePicture.png',8,'2001-03-10');
/*!40000 ALTER TABLE `dbo_student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_subject`
--

DROP TABLE IF EXISTS `dbo_subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_subject` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_subject`
--

LOCK TABLES `dbo_subject` WRITE;
/*!40000 ALTER TABLE `dbo_subject` DISABLE KEYS */;
INSERT INTO `dbo_subject` VALUES (1,'Mathematics'),(2,'Physics'),(3,'Geography'),(4,'History'),(5,'Music'),(6,'Sports Education'),(7,'Information Technology');
/*!40000 ALTER TABLE `dbo_subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_teacher`
--

DROP TABLE IF EXISTS `dbo_teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_teacher` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Address` varchar(45) NOT NULL,
  `UserId` int NOT NULL,
  `Photo` varchar(255) NOT NULL DEFAULT 'http://localhost:8887/photos/defaultProfilePicture.png',
  PRIMARY KEY (`Id`),
  KEY `fk_user_teacher_idx` (`UserId`),
  CONSTRAINT `fk_user_teacher` FOREIGN KEY (`UserId`) REFERENCES `dbo_user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_teacher`
--

LOCK TABLES `dbo_teacher` WRITE;
/*!40000 ALTER TABLE `dbo_teacher` DISABLE KEYS */;
INSERT INTO `dbo_teacher` VALUES (1,'Emilian','Ceuca','Teacher Adress',4,'http://localhost:8887/photos/defaultProfilePicture.png');
/*!40000 ALTER TABLE `dbo_teacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_teachersubject`
--

DROP TABLE IF EXISTS `dbo_teachersubject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_teachersubject` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TeacherId` int NOT NULL,
  `SubjectId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_teacher_map_idx` (`TeacherId`),
  KEY `fk_subject_map_idx` (`SubjectId`),
  CONSTRAINT `fk_subject_map` FOREIGN KEY (`SubjectId`) REFERENCES `dbo_subject` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `fk_teacher_map` FOREIGN KEY (`TeacherId`) REFERENCES `dbo_teacher` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_teachersubject`
--

LOCK TABLES `dbo_teachersubject` WRITE;
/*!40000 ALTER TABLE `dbo_teachersubject` DISABLE KEYS */;
INSERT INTO `dbo_teachersubject` VALUES (1,1,1),(2,1,2),(3,1,3);
/*!40000 ALTER TABLE `dbo_teachersubject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dbo_user`
--

DROP TABLE IF EXISTS `dbo_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dbo_user` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(45) NOT NULL,
  `Username` varchar(45) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `RoleId` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username_UNIQUE` (`Username`),
  KEY `fk_role_user_idx` (`RoleId`),
  CONSTRAINT `fk_role_user` FOREIGN KEY (`RoleId`) REFERENCES `dbo_role` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dbo_user`
--

LOCK TABLES `dbo_user` WRITE;
/*!40000 ALTER TABLE `dbo_user` DISABLE KEYS */;
INSERT INTO `dbo_user` VALUES (2,'adelinandrica@gmail.com','adelinandrica','$2a$11$d0H2zN15fvRLJFPo8RfKN.BJN37TBQYk7367zUFXogqA0Lv1cDQs6',1),(3,'ionutcutean@gmail.com','ionutcutean','$2a$11$jJ2rGkI1wwiuNq8rDn1I/.PA4f/w1OTjbHtwvQ87ANlwzZnOnIQkK',1),(4,'emilianceuca@gmail.com','emilianceuca','$2a$11$5mmC.6tuSQvZ4JSDO4v7EurM/xeBStjvD3kOpyIfUyErc.z3roF/m',2),(6,'','TestUser01','$2a$11$hheX//E.skZuhAKV.Ro.ZeFqFu0mgv6pVIDf5Zs1EKFYTW/GR09Qq',1),(7,'JohnBrown@gmail.com','TestUser012','$2a$11$2eSRlMnFCb0Yli2eX4rS6eZzyUilVwbjETEXLm942Znu6XYdyNBYK',1),(8,'JohnSmith@gmail.com','TestUser0','$2a$11$NfFveo/H7N1lCkSsQSud3uqg9eVpg/YiIPDdZ.v06eePxZVKtZSZ.',1),(9,'nomail','admin','$2y$11$WuSAhGPE99OllK2CFboJNe7CbDpLyeyBtOkgOZCVIAy8jtzcDIKMu',3);
/*!40000 ALTER TABLE `dbo_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'school_mgmsys'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-02 16:16:00
