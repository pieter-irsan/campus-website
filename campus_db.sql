-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 11, 2021 at 06:11 AM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `campus_db`
--
CREATE DATABASE IF NOT EXISTS `campus_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `campus_db`;

-- --------------------------------------------------------

--
-- Table structure for table `dosen`
--

CREATE TABLE `dosen` (
  `KodeDosen` char(3) NOT NULL,
  `NamaDosen` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dosen`
--

INSERT INTO `dosen` (`KodeDosen`, `NamaDosen`) VALUES
('FCN', 'Fachran Nazarullah, S.Kom');

-- --------------------------------------------------------

--
-- Stand-in structure for view `infomhs`
-- (See below for the actual view)
--
CREATE TABLE `infomhs` (
`NIM` int(10)
,`NamaMhs` varchar(50)
,`Jurusan` varchar(50)
,`Fakultas` varchar(50)
,`KodeKelas` char(4)
,`KodeMatkul` char(3)
,`NamaMatkul` varchar(50)
);

-- --------------------------------------------------------

--
-- Table structure for table `jadwal`
--

CREATE TABLE `jadwal` (
  `KodeKelas` char(4) NOT NULL,
  `KodeMatkul` char(3) NOT NULL,
  `NamaMatkul` varchar(50) NOT NULL,
  `SKS` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `jadwal`
--

INSERT INTO `jadwal` (`KodeKelas`, `KodeMatkul`, `NamaMatkul`, `SKS`) VALUES
('C28', 'ADB', 'Administering Database', 2),
('P20', 'WPM', 'Web Programming for Mobile Devices', 3);

-- --------------------------------------------------------

--
-- Table structure for table `kelas`
--

CREATE TABLE `kelas` (
  `KodeKelas` varchar(3) NOT NULL,
  `Ruang` varchar(30) NOT NULL,
  `Kampus` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kelas`
--

INSERT INTO `kelas` (`KodeKelas`, `Ruang`, `Kampus`) VALUES
('C28', 'Ruang 28', 'Kampus C'),
('P20', 'Ruang 20', 'Kampus P');

-- --------------------------------------------------------

--
-- Table structure for table `krs`
--

CREATE TABLE `krs` (
  `NIM` int(10) NOT NULL,
  `KodeKelas` char(4) NOT NULL,
  `KodeMatkul` char(3) NOT NULL,
  `NamaMatkul` varchar(50) NOT NULL,
  `SKS` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `krs`
--

INSERT INTO `krs` (`NIM`, `KodeKelas`, `KodeMatkul`, `NamaMatkul`, `SKS`) VALUES
(1920010183, 'C28', 'ADB', 'Administering Database', 2),
(1920010183, 'P20', 'WPM', 'Web Programming for Mobile Devices', 3);

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswa`
--

CREATE TABLE `mahasiswa` (
  `NIM` int(10) NOT NULL,
  `NamaMhs` varchar(50) NOT NULL,
  `Jurusan` varchar(50) NOT NULL,
  `Fakultas` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mahasiswa`
--

INSERT INTO `mahasiswa` (`NIM`, `NamaMhs`, `Jurusan`, `Fakultas`) VALUES
(1920010183, 'Pieter Irsan Hutagaol', 'CEP CCIT FTUI - TI-Reg', 'Fakultas Teknik'),
(1920010203, 'Yurianika Yolanda Filipi Hutapea', 'Ilmu Komunikasi', 'Fakultas Ilmu Sosial dan Ilmu Politik');

--
-- Triggers `mahasiswa`
--
DELIMITER $$
CREATE TRIGGER `HistoryTabelMahasiswa` BEFORE UPDATE ON `mahasiswa` FOR EACH ROW INSERT INTO mahasiswaaudit
SET ACTION
    = 'Update',
    NIM = OLD.NIM,
    Jurusan = OLD.Jurusan,
    Fakultas = OLD.Fakultas,
    WaktuPerubahan = NOW()
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `mahasiswaaudit`
--

CREATE TABLE `mahasiswaaudit` (
  `ID` int(11) NOT NULL,
  `NIM` int(11) NOT NULL,
  `NamaMhs` varchar(50) NOT NULL,
  `Jurusan` varchar(50) NOT NULL,
  `Fakultas` varchar(50) NOT NULL,
  `WaktuPerubahan` datetime DEFAULT NULL,
  `ACTION` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mahasiswaaudit`
--

INSERT INTO `mahasiswaaudit` (`ID`, `NIM`, `NamaMhs`, `Jurusan`, `Fakultas`, `WaktuPerubahan`, `ACTION`) VALUES
(1, 1920010183, '', 'Sastra Inggris', 'Fakultas Ilmu Pengetahuan Budaya', '2021-01-11 12:05:04', 'Update');

-- --------------------------------------------------------

--
-- Table structure for table `matkul`
--

CREATE TABLE `matkul` (
  `KodeMatkul` char(3) NOT NULL,
  `NamaMatkul` varchar(50) NOT NULL,
  `SKS` int(1) NOT NULL,
  `KodeDosen` char(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `matkul`
--

INSERT INTO `matkul` (`KodeMatkul`, `NamaMatkul`, `SKS`, `KodeDosen`) VALUES
('ADB', 'Administering Database', 2, 'FCN'),
('WPM', 'Web Programming for Mobile Devices', 3, 'FCN');

-- --------------------------------------------------------

--
-- Table structure for table `nilai`
--

CREATE TABLE `nilai` (
  `NIM` int(10) NOT NULL,
  `Nilai` int(3) NOT NULL,
  `KodeMatkul` char(3) NOT NULL,
  `NamaMatkul` varchar(50) NOT NULL,
  `KodeKelas` char(4) NOT NULL,
  `SKS` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `nilai`
--

INSERT INTO `nilai` (`NIM`, `Nilai`, `KodeMatkul`, `NamaMatkul`, `KodeKelas`, `SKS`) VALUES
(1920010183, 90, 'ADB', 'Administering Database', 'C28', 2);

-- --------------------------------------------------------

--
-- Table structure for table `tagihan`
--

CREATE TABLE `tagihan` (
  `NIM` int(1) NOT NULL,
  `JumlahTagihan` decimal(10,2) NOT NULL,
  `TglAngsuran` date NOT NULL,
  `TglBayar` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tagihan`
--

INSERT INTO `tagihan` (`NIM`, `JumlahTagihan`, `TglAngsuran`, `TglBayar`) VALUES
(1920010183, '6000000.00', '2020-01-01', '2020-02-01');

-- --------------------------------------------------------

--
-- Structure for view `infomhs`
--
DROP TABLE IF EXISTS `infomhs`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `infomhs`  AS SELECT `mhs`.`NIM` AS `NIM`, `mhs`.`NamaMhs` AS `NamaMhs`, `mhs`.`Jurusan` AS `Jurusan`, `mhs`.`Fakultas` AS `Fakultas`, `krsmhs`.`KodeKelas` AS `KodeKelas`, `krsmhs`.`KodeMatkul` AS `KodeMatkul`, `krsmhs`.`NamaMatkul` AS `NamaMatkul` FROM (`mahasiswa` `mhs` join `krs` `krsmhs` on(`krsmhs`.`NIM` = `mhs`.`NIM`)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dosen`
--
ALTER TABLE `dosen`
  ADD PRIMARY KEY (`KodeDosen`);

--
-- Indexes for table `jadwal`
--
ALTER TABLE `jadwal`
  ADD PRIMARY KEY (`KodeKelas`,`KodeMatkul`),
  ADD KEY `KodeMatkul_JadwalFK` (`KodeMatkul`);

--
-- Indexes for table `kelas`
--
ALTER TABLE `kelas`
  ADD PRIMARY KEY (`KodeKelas`);

--
-- Indexes for table `krs`
--
ALTER TABLE `krs`
  ADD PRIMARY KEY (`NIM`,`KodeKelas`,`KodeMatkul`),
  ADD KEY `KodeKelas_krsFK` (`KodeKelas`),
  ADD KEY `KodeMatkul_krsFK` (`KodeMatkul`);

--
-- Indexes for table `mahasiswa`
--
ALTER TABLE `mahasiswa`
  ADD PRIMARY KEY (`NIM`);

--
-- Indexes for table `mahasiswaaudit`
--
ALTER TABLE `mahasiswaaudit`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `matkul`
--
ALTER TABLE `matkul`
  ADD PRIMARY KEY (`KodeMatkul`),
  ADD KEY `KodeDosen_MatkulFK` (`KodeDosen`);

--
-- Indexes for table `nilai`
--
ALTER TABLE `nilai`
  ADD PRIMARY KEY (`NIM`,`KodeMatkul`),
  ADD KEY `KodeKelas_NilaiFK` (`KodeKelas`),
  ADD KEY `KodeMatkul_NilaiFK` (`KodeMatkul`);

--
-- Indexes for table `tagihan`
--
ALTER TABLE `tagihan`
  ADD PRIMARY KEY (`NIM`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `mahasiswaaudit`
--
ALTER TABLE `mahasiswaaudit`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `jadwal`
--
ALTER TABLE `jadwal`
  ADD CONSTRAINT `KodeKelas_JadwalFK` FOREIGN KEY (`KodeKelas`) REFERENCES `kelas` (`KodeKelas`),
  ADD CONSTRAINT `KodeMatkul_JadwalFK` FOREIGN KEY (`KodeMatkul`) REFERENCES `matkul` (`KodeMatkul`);

--
-- Constraints for table `krs`
--
ALTER TABLE `krs`
  ADD CONSTRAINT `KodeKelas_krsFK` FOREIGN KEY (`KodeKelas`) REFERENCES `kelas` (`KodeKelas`),
  ADD CONSTRAINT `KodeMatkul_krsFK` FOREIGN KEY (`KodeMatkul`) REFERENCES `matkul` (`KodeMatkul`),
  ADD CONSTRAINT `NIM_krsFK` FOREIGN KEY (`NIM`) REFERENCES `mahasiswa` (`NIM`);

--
-- Constraints for table `matkul`
--
ALTER TABLE `matkul`
  ADD CONSTRAINT `KodeDosen_MatkulFK` FOREIGN KEY (`KodeDosen`) REFERENCES `dosen` (`KodeDosen`);

--
-- Constraints for table `nilai`
--
ALTER TABLE `nilai`
  ADD CONSTRAINT `KodeKelas_NilaiFK` FOREIGN KEY (`KodeKelas`) REFERENCES `kelas` (`KodeKelas`),
  ADD CONSTRAINT `KodeMatkul_NilaiFK` FOREIGN KEY (`KodeMatkul`) REFERENCES `matkul` (`KodeMatkul`),
  ADD CONSTRAINT `NIM_NilaiFK` FOREIGN KEY (`NIM`) REFERENCES `mahasiswa` (`NIM`);

--
-- Constraints for table `tagihan`
--
ALTER TABLE `tagihan`
  ADD CONSTRAINT `NIM_TagihanFK` FOREIGN KEY (`NIM`) REFERENCES `mahasiswa` (`NIM`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
