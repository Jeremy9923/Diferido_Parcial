
--
CREATE DATABASE IF NOT EXISTS `parcial` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `parcial`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumno`
--

CREATE TABLE `alumno` (
  `codAlumno` int(11) NOT NULL,
  `nombres` text NOT NULL,
  `apellidos` text NOT NULL,
  `edad` int(11) NOT NULL,
  `direccion` text NOT NULL,
  PRIMARY KEY (`codAlumno`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

