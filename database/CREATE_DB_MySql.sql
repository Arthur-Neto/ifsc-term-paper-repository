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
-- Table `TCCDB_IFSC`.`Areas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Areas` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Areas` (
  `AreaID` INT NOT NULL AUTO_INCREMENT,
  `Name` NVARCHAR(50) NOT NULL,
  PRIMARY KEY (`AreaID`),
  UNIQUE INDEX `Name_UNIQUE` (`Name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Courses`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Courses` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Courses` (
  `CourseID` INT NOT NULL AUTO_INCREMENT,
  `AreaID` INT NOT NULL,
  `Name` NVARCHAR(100) NOT NULL,
  PRIMARY KEY (`CourseID`),
  INDEX `FK_Courses_Areas_idx` (`AreaID` ASC) VISIBLE,
  CONSTRAINT `FK_Courses_Areas`
    FOREIGN KEY (`AreaID`)
    REFERENCES `TCCDB_IFSC`.`Areas` (`AreaID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Keywords`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Keywords` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Keywords` (
  `KeywordID` INT NOT NULL AUTO_INCREMENT,
  `Value` NVARCHAR(50) NOT NULL,
  PRIMARY KEY (`KeywordID`),
  UNIQUE INDEX `Value_UNIQUE` (`Value` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`TermPapers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`TermPapers` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`TermPapers` (
  `TermPaperID` INT NOT NULL AUTO_INCREMENT,
  `CourseID` INT NOT NULL,
  `Title` NVARCHAR(100) NOT NULL,
  `DateBegin` DATETIME NOT NULL,
  `DateEnd` DATETIME NOT NULL,
  `FileName` NVARCHAR(100) NOT NULL,
  PRIMARY KEY (`TermPaperID`),
  UNIQUE INDEX `Title_UNIQUE` (`Title` ASC) VISIBLE,
  INDEX `FK_TermPapers_Courses_idx` (`CourseID` ASC) VISIBLE,
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
  PRIMARY KEY (`StudentID`),
  INDEX `FK_Students_TermPapers_idx` (`TermPaperID` ASC) VISIBLE,
  CONSTRAINT `FK_Students_TermPapers`
    FOREIGN KEY (`TermPaperID`)
    REFERENCES `TCCDB_IFSC`.`TermPapers` (`TermPaperID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`Advisors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`Advisors` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`Advisors` (
  `AdvisorID` INT NOT NULL AUTO_INCREMENT,
  `Login` VARCHAR(50) NOT NULL,
  `Password` VARCHAR(200) NOT NULL,
  `Name` NVARCHAR(50) NOT NULL,
  PRIMARY KEY (`AdvisorID`),
  UNIQUE INDEX `Login_UNIQUE` (`Login` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`TermPapers_Advisors`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`TermPapers_Advisors` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`TermPapers_Advisors` (
  `TermPaperID` INT NOT NULL,
  `AdvisorID` INT NOT NULL,
  `AdvisorType` INT NOT NULL,
  PRIMARY KEY (`TermPaperID`, `AdvisorID`),
  INDEX `FK_TermPapers_Advisors_Advisors_idx` (`AdvisorID` ASC) VISIBLE,
  CONSTRAINT `FK_TermPapers_Advisors_Advisors`
    FOREIGN KEY (`AdvisorID`)
    REFERENCES `TCCDB_IFSC`.`Advisors` (`AdvisorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_TermPapers_Advisors_TermPapers`
    FOREIGN KEY (`TermPaperID`)
    REFERENCES `TCCDB_IFSC`.`TermPapers` (`TermPaperID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TCCDB_IFSC`.`TermPapers_Keywords`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TCCDB_IFSC`.`TermPapers_Keywords` ;

CREATE TABLE IF NOT EXISTS `TCCDB_IFSC`.`TermPapers_Keywords` (
  `TermPaperID` INT NOT NULL,
  `KeywordID` INT NOT NULL,
  PRIMARY KEY (`TermPaperID`, `KeywordID`),
  INDEX `FK_TermPapers_Keywords_Keywords_idx` (`KeywordID` ASC) VISIBLE,
  CONSTRAINT `FK_TermPapers_Keywords_TermPapers`
    FOREIGN KEY (`TermPaperID`)
    REFERENCES `TCCDB_IFSC`.`TermPapers` (`TermPaperID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_TermPapers_Keywords_Keywords`
    FOREIGN KEY (`KeywordID`)
    REFERENCES `TCCDB_IFSC`.`Keywords` (`KeywordID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
