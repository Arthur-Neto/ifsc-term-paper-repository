-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema TCCDB_IFSC
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema TCCDB_IFSC
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `TCCDB_IFSC` DEFAULT CHARACTER SET utf8 ;
USE `TCCDB_IFSC` ;

-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Courses`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Courses` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Courses` (
  `CourseID` INT NOT NULL AUTO_INCREMENT,
  `Name` NVARCHAR(100) NOT NULL,
  PRIMARY KEY (`CourseID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Areas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Areas` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Areas` (
  `AreaID` INT NOT NULL AUTO_INCREMENT,
  `Name` NVARCHAR(50) NOT NULL,
  PRIMARY KEY (`AreaID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Keywords`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Keywords` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Keywords` (
  `KeywordID` INT NOT NULL AUTO_INCREMENT,
  `Value` NVARCHAR(50) NOT NULL,
  PRIMARY KEY (`KeywordID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`TermPapers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`TermPapers` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`TermPapers` (
  `TermPaperID` INT NOT NULL AUTO_INCREMENT,
  `AreaID` INT NOT NULL,
  `CourseID` INT NOT NULL,
  `Title` NVARCHAR(100) NOT NULL,
  `DateBegin` DATETIME NOT NULL,
  `DateEnd` DATETIME NULL,
  PRIMARY KEY (`TermPaperID`),
  INDEX `FK_TermPapers_Areas_idx` (`AreaID` ASC) VISIBLE,
  INDEX `FK_TermPapers_Courses_idx` (`CourseID` ASC) VISIBLE,
  CONSTRAINT `FK_TermPapers_Areas`
    FOREIGN KEY (`AreaID`)
    REFERENCES `TCCDB_IFSC`.`Areas` (`AreaID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_TermPapers_Courses`
    FOREIGN KEY (`CourseID`)
    REFERENCES `TCCDB_IFSC`.`Courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Students`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Students` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Students` (
  `StudentID` INT NOT NULL AUTO_INCREMENT,
  `TermPaperID` INT NOT NULL,
  `Name` NVARCHAR(50) NOT NULL,
  `RegistrationNumber` VARCHAR(50) NOT NULL,
  `Email` VARCHAR(50) NOT NULL,
  `Password` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`StudentID`),
  INDEX `FK_Students_TermPapers_idx` (`TermPaperID` ASC) VISIBLE,
  CONSTRAINT `FK_Students_TermPapers`
    FOREIGN KEY (`TermPaperID`)
    REFERENCES `TCCDB_IFSC`.`TermPapers` (`TermPaperID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`TermPaperFileTypes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`TermPaperFileTypes` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`TermPaperFileTypes` (
  `TermPaperFileTypesID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(25) NOT NULL,
  PRIMARY KEY (`TermPaperFileTypesID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`TermPaperFiles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`TermPaperFiles` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`TermPaperFiles` (
  `TermPaperFileID` INT NOT NULL AUTO_INCREMENT,
  `TermPaperID` INT NOT NULL,
  `TermPaperFileTypeID` INT NOT NULL,
  `FileName` NVARCHAR(50) NOT NULL,
  `TermPaperData` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`TermPaperFileID`),
  INDEX `FK_TermPaperFiles_TermPaperFileTypes_idx` (`TermPaperFileTypeID` ASC) VISIBLE,
  INDEX `FK_TermPaperFiles_TermPapers_idx` (`TermPaperID` ASC) VISIBLE,
  CONSTRAINT `FK_TermPaperFiles_TermPaperFileTypes`
    FOREIGN KEY (`TermPaperFileTypeID`)
    REFERENCES `TCCDB_IFSC`.`TermPaperFileTypes` (`TermPaperFileTypesID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_TermPaperFiles_TermPapers`
    FOREIGN KEY (`TermPaperID`)
    REFERENCES `TCCDB_IFSC`.`TermPapers` (`TermPaperID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`AdvisorTypes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`AdvisorTypes` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`AdvisorTypes` (
  `AdvisorTypesID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(25) NOT NULL,
  PRIMARY KEY (`AdvisorTypesID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Advisors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Advisors` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Advisors` (
  `AdvisorID` INT NOT NULL,
  `AdvisorTypeID` INT NOT NULL,
  `Login` VARCHAR(50) NOT NULL,
  `Password` VARCHAR(200) NOT NULL,
  `Name` NVARCHAR(50) NOT NULL,
  PRIMARY KEY (`AdvisorID`),
  INDEX `FK_Advisors_AdvisorTypes_idx` (`AdvisorTypeID` ASC) VISIBLE,
  CONSTRAINT `FK_Advisors_AdvisorTypes`
    FOREIGN KEY (`AdvisorTypeID`)
    REFERENCES `TCCDB_IFSC`.`AdvisorTypes` (`AdvisorTypesID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`TermPapers_Advisors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`TermPapers_Advisors` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`TermPapers_Advisors` (
  `TermPaperID` INT NOT NULL,
  `AdvisorID` INT NOT NULL,
  PRIMARY KEY (`TermPaperID`, `AdvisorID`),
  INDEX `FK_TermPapers_Advisors_Advisors_idx` (`AdvisorID` ASC) VISIBLE,
  CONSTRAINT `FK_TermPapers_Advisors_TermPapers`
    FOREIGN KEY (`TermPaperID`)
    REFERENCES `TCCDB_IFSC`.`TermPapers` (`TermPaperID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_TermPapers_Advisors_Advisors`
    FOREIGN KEY (`AdvisorID`)
    REFERENCES `TCCDB_IFSC`.`Advisors` (`AdvisorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Keywords_TermPapers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Keywords_TermPapers` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Keywords_TermPapers` (
  `KeywordID` INT NOT NULL,
  `TermPaperID` INT NOT NULL,
  PRIMARY KEY (`KeywordID`, `TermPaperID`),
  INDEX `FK_Keywords_TermPapers_TermPapers_idx` (`TermPaperID` ASC) VISIBLE,
  CONSTRAINT `FK_Keywords_TermPapers_TermPapers`
    FOREIGN KEY (`TermPaperID`)
    REFERENCES `TCCDB_IFSC`.`TermPapers` (`TermPaperID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Keywords_TermPapers_Keywords`
    FOREIGN KEY (`KeywordID`)
    REFERENCES `TCCDB_IFSC`.`Keywords` (`KeywordID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `TCCDB_IFSC`.`TermPaperFileTypes`
-- -----------------------------------------------------
START TRANSACTION;
USE `TCCDB_IFSC`;
INSERT INTO `TCCDB_IFSC`.`TermPaperFileTypes` (`TermPaperFileTypesID`, `Name`) VALUES (1, 'Report');
INSERT INTO `TCCDB_IFSC`.`TermPaperFileTypes` (`TermPaperFileTypesID`, `Name`) VALUES (2, 'FinalDocument');

COMMIT;


-- -----------------------------------------------------
-- Data for table `TCCDB_IFSC`.`AdvisorTypes`
-- -----------------------------------------------------
START TRANSACTION;
USE `TCCDB_IFSC`;
INSERT INTO `TCCDB_IFSC`.`AdvisorTypes` (`AdvisorTypesID`, `Name`) VALUES (1, 'Leader');
INSERT INTO `TCCDB_IFSC`.`AdvisorTypes` (`AdvisorTypesID`, `Name`) VALUES (2, 'CoLeader');
INSERT INTO `TCCDB_IFSC`.`AdvisorTypes` (`AdvisorTypesID`, `Name`) VALUES (3, 'TermPaperTeacher');

COMMIT;

