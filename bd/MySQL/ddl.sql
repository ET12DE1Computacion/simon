-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Simon
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `Simon` ;

-- -----------------------------------------------------
-- Schema Simon
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Simon` DEFAULT CHARACTER SET utf8 ;
USE `Simon` ;

-- -----------------------------------------------------
-- Table `Simon`.`Jugador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Simon`.`Jugador` (
  `idJugador` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idJugador`),
  UNIQUE INDEX `nombre_UNIQUE` (`nombre` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Simon`.`Juego`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Simon`.`Juego` (
  `idJugador` INT NOT NULL,
  `dificultad` INT NOT NULL,
  `puntos` INT NOT NULL,
  PRIMARY KEY (`idJugador`, `dificultad`),
  INDEX `fk_Juego_Jugador_idx` (`idJugador` ASC),
  UNIQUE INDEX `uq_idJugador_dificultad` (`idJugador` ASC, `dificultad` ASC),
  CONSTRAINT `fk_Juego_Jugador`
    FOREIGN KEY (`idJugador`)
    REFERENCES `Simon`.`Jugador` (`idJugador`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `Simon` ;

-- -----------------------------------------------------
-- procedure altaJugador
-- -----------------------------------------------------

DELIMITER $$
USE `Simon`$$
CREATE PROCEDURE altaJugador (nombreJugador varchar(45), OUT unIdJugador int)
BEGIN
	INSERT INTO jugador(nombre) VALUES (nombreJugador);
	SELECT last_insert_id() INTO unIdJugador;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sumarPuntos
-- -----------------------------------------------------

DELIMITER $$
USE `Simon`$$
CREATE PROCEDURE sumarPuntos(unIdJugador int, unaDificultad int, pts int)
BEGIN
	DECLARE puntosJuego int DEFAULT NULL;
	
	SELECT	puntos INTO puntosJuego
	FROM	Juego
	WHERE	idJugador=unIdJugador
	AND		dificultad=unaDificultad;

	IF (puntosJuego IS null) THEN
		INSERT INTO Juego (idJugador,dificultad,puntos) VALUES(unIdJugador,unaDificultad,pts);
	ELSE
		IF (puntosJuego<pts) THEN
			UPDATE	Juego
			SET		puntos = pts
			WHERE	idJugador=unIdJugador
			AND		dificultad=unaDificultad;
		END IF;
	END IF;
		
	
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure puntaje
-- -----------------------------------------------------

DELIMITER $$
USE `Simon`$$
CREATE PROCEDURE puntaje ()
BEGIN
	SELECT			nombre, dificultad, puntos
	FROM			Jugador
	NATURAL JOIN	Juego
	ORDER BY dificultad desc, puntos desc, nombre asc;
END$$

DELIMITER ;
DROP USER IF exists 'simon'@'%';
CREATE USER 'simon'@'%' IDENTIFIED BY 'simon';

GRANT ALL ON `Simon`.* TO 'simon'@'%';

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
