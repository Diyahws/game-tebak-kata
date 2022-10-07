-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 27 Bulan Mei 2022 pada 09.08
-- Versi server: 10.4.24-MariaDB
-- Versi PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_game`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `leaderboard`
--

CREATE TABLE `leaderboard` (
  `no` int(11) NOT NULL,
  `score` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `leaderboard`
--

INSERT INTO `leaderboard` (`no`, `score`) VALUES
(1, 6),
(2, 0);

-- --------------------------------------------------------

--
-- Struktur dari tabel `words`
--

CREATE TABLE `words` (
  `no` int(11) NOT NULL,
  `word` varchar(25) NOT NULL,
  `hint1` varchar(255) NOT NULL,
  `hint2` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `words`
--

INSERT INTO `words` (`no`, `word`, `hint1`, `hint2`) VALUES
(1, 'tomat', 'Tumbuhan', 'Buah-buahan'),
(2, 'komputer', 'Alat', 'Teknologi'),
(3, 'apartemen', 'Tempat', 'Bangunan'),
(4, 'hutan', 'Tempat', 'Pepohonan'),
(5, 'cokelat', 'Makanan', 'Olahan'),
(6, 'pengacara', 'Profesi', 'Pengadilan');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `leaderboard`
--
ALTER TABLE `leaderboard`
  ADD PRIMARY KEY (`no`);

--
-- Indeks untuk tabel `words`
--
ALTER TABLE `words`
  ADD PRIMARY KEY (`no`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `leaderboard`
--
ALTER TABLE `leaderboard`
  MODIFY `no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT untuk tabel `words`
--
ALTER TABLE `words`
  MODIFY `no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
