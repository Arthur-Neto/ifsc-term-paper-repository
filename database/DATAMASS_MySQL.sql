-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: tccdb_ifsc
-- ------------------------------------------------------
-- Server version	8.0.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `advisors`
--

INSERT INTO advisors VALUES (1,'alexandre.perin','123','Alexandre Perin');
INSERT INTO advisors VALUES (2,'andre.savara','123','André Savara');

--
-- Dumping data for table `advisortypes`
--

INSERT INTO advisortypes VALUES (2,'CoLeader');
INSERT INTO advisortypes VALUES (1,'Leader');

--
-- Dumping data for table `areas`
--

INSERT INTO areas VALUES (1,'Informática e Tecnologia');

--
-- Dumping data for table `courses`
--

INSERT INTO courses VALUES (1,1,'Ciência da Computação');

--
-- Dumping data for table `groupfiles`
--


--
-- Dumping data for table `groups`
--

INSERT INTO groups VALUES (1,1);
INSERT INTO groups VALUES (2,1);
INSERT INTO groups VALUES (3,1);
INSERT INTO groups VALUES (4,1);

--
-- Dumping data for table `groups_advisors`
--

INSERT INTO groups_advisors VALUES (1,1,1);
INSERT INTO groups_advisors VALUES (2,1,1);
INSERT INTO groups_advisors VALUES (3,2,1);

--
-- Dumping data for table `keywords`
--


--
-- Dumping data for table `students`
--

INSERT INTO students VALUES (1,1,'Arthur Neto','123456789','arthur.neto@ifsc.edu.br','123');
INSERT INTO students VALUES (2,1,'Johnson Sadao','987654321','johnson.sadao@ifsc.edu.br','123');
INSERT INTO students VALUES (3,2,'Victor Klann','24','victor.klann@ifsc.edu.br','123');
INSERT INTO students VALUES (4,3,'Matheus Guimaraes','147258369','matheus.guima','123');
INSERT INTO students VALUES (5,3,'Giovani Girardi','369852147','giovani.girardi','123');
INSERT INTO students VALUES (6,4,'Lucas Chaves','1597534862','lucas.chaves','123');
INSERT INTO students VALUES (7,4,'Matheus Medeiros','9513578426','matheus.medeiros','123');

--
-- Dumping data for table `termpapers`
--


--
-- Dumping data for table `termpapers_keywords`
--


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed
