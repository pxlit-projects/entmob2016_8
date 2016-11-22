-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Gegenereerd op: 22 nov 2016 om 11:45
-- Serverversie: 10.1.16-MariaDB
-- PHP-versie: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `entmob`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `credentials`
--

CREATE TABLE `credentials` (
  `user_id` int(11) NOT NULL,
  `service` varchar(20) NOT NULL,
  `user_name` varchar(20) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `sessions`
--

CREATE TABLE `sessions` (
  `session_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `start_time` bigint(20) NOT NULL,
  `end_time` bigint(20) NOT NULL,
  `actual_time` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `sessions`
--

INSERT INTO `sessions` (`session_id`, `user_id`, `start_time`, `end_time`, `actual_time`) VALUES
(1, 13, 1478264400, 1478275200, 10),
(2, 13, 1478264400, 1478279815, 5),
(3, 12, 1478257255, 1478271595, 2),
(4, 12, 1478271595, 1478273455, 10),
(5, 12, 1478262655, 1478275830, 4),
(6, 1, 1478521948491, 1478521968491, 10),
(7, 1, 1478523099022, 1478523119022, 10),
(8, 1, 1478771783507, 1478771803507, 10),
(9, 7, 1479807737, 1479807786, 48),
(10, 7, 1479807814, 1479807832, 18),
(11, 7, 1479807846, 1479807880, 33);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `first_name` varchar(20) NOT NULL,
  `last_name` varchar(20) NOT NULL,
  `password` varchar(130) NOT NULL,
  `salt` varchar(50) NOT NULL,
  `department` varchar(20) NOT NULL,
  `role` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`user_id`, `first_name`, `last_name`, `password`, `salt`, `department`, `role`) VALUES
(7, 'Koen', 'Castermans', 'd18219f3d7dacf0acfe3a0941f761fd3fa76d39da497eb5bb5abce728484910b5cd8d3eb8a81bc3ce6332bf7b88e380aa9922df150d3bd4e1b1ff58f860751c8', 'koen', 'verkoop', 'admin'),
(11, 'Jaap', 'Aap', 'jaapjaap', 'jaap', 'aankoop', 'admin'),
(12, 'Stephane', 'Oris', 'stephanestephane', 'stephane', 'verkoop', 'user'),
(13, 'Jasper', 'Skudzlarski', 'jasperjasper', 'jasper', 'aankoop', 'user'),
(46, 'brecht', 'morrhey', 'test', 'test', 'test', 'test'),
(47, 'Jan', 'Jansen', '54522cc86f7823d62ff4eab6c24a0b48bd373d5825ce39616f163f402e69bea4b942d4c7b36131dc9a96f0aa9607d6e66fbd98417811b78ee85a6b81750b5b6b', 'xE=8?5Ts7Nm/&6QiX}w2*4CkJ!j39f', 'lel', 'user'),
(48, 'brecht', 'morrhey', 'test', 'test', 'test', 'test'),
(49, 'brecht', 'morrhey', 'test', 'test', 'test', 'test'),
(50, 'brecht', 'morrhey', 'test', 'test', 'test', 'test'),
(51, 'Jaap', 'Aap', '0c71d27d35ab63a8778b6bc358f89d759b1c9b670c00d7f190bcc9836cd500a81cd646f27ec9b1ad4d4bfd563257a42e28ca3f9091767314825b247fd733dcb6', 'Ti6}o5+JB&r27bY*N8-g/Md3w4W=_L', 'Verkoop', 'user'),
(52, 'Koen', 'Castermans', 'f1947ee8fb612f093be7e9f8c02a8fee29d6f306abab7cb6f79ee047d783d7a1950c8016e5742c69bcdaf542ea1fe78884fccbf63486ddd3d530d4a10fab9b5f', 'P!x5kN7/4i*CQ2j_wF%36eD=c{9E?8', 'Manager', 'user'),
(53, 'Test', 'Tester', '69ef14eb53f5ae03584adb4ad29f2156a0d6c5cd35321a530551418f34f67d00701036a75b9ad1de95e1806863e930f8ab1d204b3931ece2c089aab7fea5a211', '2Zs=x/K4$5wH3jT}-J8gf!B69Pk+D?', 'Testing', 'user'),
(54, 'Test', 'TESTER', 'b39cc896b27a26af09a71ec2cb894dcd72de4abe07836f5c42d4486c0a9bf870c864278254168dddedd3273b2b7a7cc00157ef71825796ccc2151477e0c6aed8', 'E}a2-7NqmW_5{y4JzG$3&r8MC%x69R', 'TESTING', 'user');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `sessions`
--
ALTER TABLE `sessions`
  ADD PRIMARY KEY (`session_id`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `sessions`
--
ALTER TABLE `sessions`
  MODIFY `session_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
