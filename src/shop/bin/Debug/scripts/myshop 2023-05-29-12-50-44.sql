-- MySqlBackup.NET 2.3.6
-- Dump Time: 2023-05-29 12:50:44
-- --------------------------------------
-- Server version 8.0.31 MySQL Community Server - GPL


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb3 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of categoryproduct
-- 

DROP TABLE IF EXISTS `categoryproduct`;
CREATE TABLE IF NOT EXISTS `categoryproduct` (
  `id` int NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(45) NOT NULL,
  `categoryDiscount` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- 
-- Dumping data for table categoryproduct
-- 

/*!40000 ALTER TABLE `categoryproduct` DISABLE KEYS */;
INSERT INTO `categoryproduct`(`id`,`categoryName`,`categoryDiscount`) VALUES(1,'Кольца',0),(2,'Броши',0),(3,'Подвески и шармы',0),(4,'Серьги',0),(5,'Браслеты',0);
/*!40000 ALTER TABLE `categoryproduct` ENABLE KEYS */;

-- 
-- Definition of manufacturer
-- 

DROP TABLE IF EXISTS `manufacturer`;
CREATE TABLE IF NOT EXISTS `manufacturer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `manufacturerName` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb3;

-- 
-- Dumping data for table manufacturer
-- 

/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer`(`id`,`manufacturerName`) VALUES(1,'SOKOLOV'),(2,'Alexandra Gr'),(3,'Ювелирная студия Ильи Палкина'),(4,'BAUKOFF jewelry'),(5,'SILVERME'),(6,'POKROVSKY JEWELRY'),(7,'JeweLi'),(8,'Lamponi'),(9,'poemiq'),(10,'Голден Глоб'),(11,'Агра'),(12,'Золото Русских');
/*!40000 ALTER TABLE `manufacturer` ENABLE KEYS */;

-- 
-- Definition of pickuppoint
-- 

DROP TABLE IF EXISTS `pickuppoint`;
CREATE TABLE IF NOT EXISTS `pickuppoint` (
  `id` int NOT NULL AUTO_INCREMENT,
  `pickuppointName` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;

-- 
-- Dumping data for table pickuppoint
-- 

/*!40000 ALTER TABLE `pickuppoint` DISABLE KEYS */;
INSERT INTO `pickuppoint`(`id`,`pickuppointName`) VALUES(1,'ОноОно'),(2,'Всегдаоно'),(3,'vsdf'),(6,'asd'),(7,'Новый'),(8,'Другой');
/*!40000 ALTER TABLE `pickuppoint` ENABLE KEYS */;

-- 
-- Definition of product
-- 

DROP TABLE IF EXISTS `product`;
CREATE TABLE IF NOT EXISTS `product` (
  `articule` varchar(40) NOT NULL,
  `productName` varchar(100) NOT NULL,
  `idCategory` int NOT NULL,
  `description` text,
  `cost` int NOT NULL,
  `image` varchar(45) DEFAULT NULL,
  `idManufacturer` int DEFAULT NULL,
  `discount` int DEFAULT NULL,
  `unit` varchar(45) NOT NULL,
  `countStock` varchar(45) NOT NULL,
  PRIMARY KEY (`articule`),
  KEY `fg_idx` (`idManufacturer`),
  KEY `dsf_idx` (`idCategory`),
  CONSTRAINT `dsf` FOREIGN KEY (`idCategory`) REFERENCES `categoryproduct` (`id`),
  CONSTRAINT `fg` FOREIGN KEY (`idManufacturer`) REFERENCES `manufacturer` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- 
-- Dumping data for table product
-- 

/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product`(`articule`,`productName`,`idCategory`,`description`,`cost`,`image`,`idManufacturer`,`discount`,`unit`,`countStock`) VALUES('10516377','Ювелирное кольцо женское из серебра 925',1,'Женское широкое кольцо из серебра 925 пробы с дорожкой из фианитов',3390,'10516377.png',1,62,'шт.','5'),('10516469','Ювелирная брошь женская из серебра 925',2,'Броши',10490,'',1,63,'шт.','0'),('10589463','Ювелирные серьги',4,'Серьги изготовлены из золота 585 пробы. Характеристика вставок: Бриллиант 66 штук 2/2 Кр-17 0,2 карата. Средний вес составляет 1,91 грамма.',49575,'10589463.png',2,64,'шт.','3'),('11772501','Ювелирная подвеска/кулон на шею золото 585',3,'Женская подвеска на шею из красного золота 585 пробы с фианитами и топазом в форме золотой рыбки',24990,'11772501.png',1,63,'шт.','3'),('13497820','Брошь Ангел',2,'',6800,'13497820.png',3,30,'шт.','4'),('139370370','Брошь булавка серебряная 925 медицинская',2,'Серебряные ювелирные изделия от Российского бренда Lamponi (Лампони)- стильные модные украшения из серебра 925 пробы',27978,'139370370.png',8,92,'шт.','9'),('141009593','Ювелирный браслет',5,'Плетение браслета Бисмарк двухрядный и имеет ширину 2,1 мм. На украшении выполнена алмазная огранка, что придает ему дополнительный блеск. Для плетения браслета используется проволока диаметром 0,35 мм, что говорит о его прочности и долговечности.',17105,'141009593.png',9,55,'шт.','11'),('143366309','Ювелирное кольцо женское из золота 585',1,'Кольцо женское золотое 585 пробы. Вес 0.63 г',5977,'143366309.png',10,26,'шт.','5'),('147951219','Золотое кольцо клевер с камнями желтое золото 585',1,'Кольцо женское выполнено из желтого золота 585 пробы. Вставка - Фианиты 5А (искусственный аналог бриллианта).',39300,'147951219.png',11,56,'шт.','10'),('151299335','Браслет-слейв на цепочке серебро 925',5,'Браслет серебро 925 пробы с фианитами, средний вес 2.2г.',3090,'151299335.png',12,23,'шт.','6'),('16300196','Ювелирные серьги цепочки/протяжки из золота 585',4,'Женские длинные серьги-протяжки/продевки/цепочки из красного золота 585 пробы с топазами в форме капли.',22990,'16300196.png',1,63,'шт.','5'),('18001852','Брошь',2,'Брошь выполнена из серебра 925 пробы, покрытая родием и эмалью.',5300,'18001852.png',4,38,'шт.','9'),('18256839','Серьги серебро 925 гвоздики клевер пусеты с камнем\n',4,'Серьги изготовлены из серебра 925 пробы, покрытого драгоценным металлом платиновой группы - родием (rh). Средний вес составляет 1.3 г.',3000,'18256839.png',5,42,'шт.','6'),('2945090','Ювелирное кольцо-печатка мужское из серебра 925',1,'Мужское кольцо-печатка из серебра 925 пробы с дорожкой из фианитов',6390,'2945090.png',1,62,'шт.','6'),('36012488','Браслет серебро 925 на руку цепочка бесконечность',5,'Длина украшения регулируется от 16 до 19 см.',2800,'36012488.png',5,30,'шт.','6'),('40660151','Браслет серебро 925 цепочка на руку',5,'Женский серебряный браслет серебро 925 проба. Цепь с фианитами на руку. Цепочка с камнями.',3000,'40660151.png',5,23,'шт.','3'),('4790772','брошь из серебра 925 пробы',2,'Изделие выполнено из серебра 925 пробы; Вставка: 1 Корунд синт.недраг Круг 3,50, 1 Корунд синт.недраг Круг 4,50, 2 Корунд синт.недраг Круг 5,00, 1 Корунд синт.недраг Груша 7,00*5,00, 3 Корунд синт.не',10490,'4790772.png',1,63,'шт.','9'),('67526566','Золотая подвеска на шею буква А 585',3,'Золотая подвеска на шею буква А 585 - классическое ювелирное украшение для женщины, для подростков и для девочек.',7581,'67526566.png',6,38,'шт.','10'),('8056904','Ювелирная подвеска/кулон на шею серебро 925',3,'Женская подвеска на шею из серебра 925 пробы с фианитами в форме круга',2790,'8056904.png',1,62,'шт.','5'),('88051397','Браслет на нити из Сапфиров Серебро 925',5,'Браслет серебро 925 пробы, средний вес 1г.',3300,'88051397.png',7,36,'шт.','9'),('95658230','Подвеска на шею на леске кулон серебро 925 камень',3,'Размер лески - 38 см.',1500,'95658230.png',5,24,'шт.','8'),('dfg','dfg',2,'',43,'',1,NULL,'fg','18'),('fdg34','gfdgdfg',1,'',324,'',1,NULL,'шт.','9');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;

-- 
-- Definition of roleuser
-- 

DROP TABLE IF EXISTS `roleuser`;
CREATE TABLE IF NOT EXISTS `roleuser` (
  `id` int NOT NULL AUTO_INCREMENT,
  `roleName` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;

-- 
-- Dumping data for table roleuser
-- 

/*!40000 ALTER TABLE `roleuser` DISABLE KEYS */;
INSERT INTO `roleuser`(`id`,`roleName`) VALUES(1,'Администратор'),(2,'Клиент'),(3,'Менеджер');
/*!40000 ALTER TABLE `roleuser` ENABLE KEYS */;

-- 
-- Definition of statusorder
-- 

DROP TABLE IF EXISTS `statusorder`;
CREATE TABLE IF NOT EXISTS `statusorder` (
  `id` int NOT NULL AUTO_INCREMENT,
  `statusTitle` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;

-- 
-- Dumping data for table statusorder
-- 

/*!40000 ALTER TABLE `statusorder` DISABLE KEYS */;
INSERT INTO `statusorder`(`id`,`statusTitle`) VALUES(1,'Ожидается'),(2,'Получен'),(3,'Отменен'),(4,'Принят'),(5,'Отсортирован'),(6,'Оформлен');
/*!40000 ALTER TABLE `statusorder` ENABLE KEYS */;

-- 
-- Definition of user
-- 

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fio` varchar(100) DEFAULT NULL,
  `login` varchar(13) DEFAULT NULL,
  `passwd` varchar(6) DEFAULT NULL,
  `idrole` int DEFAULT NULL,
  `birthday` varchar(20) DEFAULT NULL,
  `telephone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb3;

-- 
-- Dumping data for table user
-- 

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user`(`id`,`fio`,`login`,`passwd`,`idrole`,`birthday`,`telephone`) VALUES(1,'Смирнов Мирон Русланович','loginqABDzzNc','~C6$h?',1,'1974-10-08','+7(057)075-62-76'),(2,'Некрасова Екатерина Максимовна','loginalRLmcMR','I\\?*0p',3,'1996-04-02','+7(426)316-69-21'),(3,'Краснов Богдан Николаевич','logincbMDTykG','?QLz00',2,'1997-07-28','+7(285)107-20-46'),(4,'Зайцева Анна Константиновна','loginBbaoYECf','g7Zd0)',2,'1971-07-18','+7(141)494 93-76'),(5,'Моисеев Николай Георгиевич','loginGkqDfcip','W8q2k!',3,'1998-08-12','+7(076)760 92-28'),(6,'Рожков Александр Матвеевич','loginctFmMOVn','Mv3[Su',3,'1972-12-06','+7(279)849-06-08'),(7,'Баранов Платон Романович','loginWQOusQjQ','mw1M{m',3,'1973-09-14','+7(962)396-40-31'),(8,'Игнатов Алексей Фёдорович','loginSSmqRpUQ','}\\Z1u5',3,'1985-01-20','+7(072)606-68-69'),(9,'Григорьев Алексей Ильич','loginahHUiSgI','|KsV84',2,'1985-05-21','+7(086)579-87-37'),(10,'Сухов Павел Олегович','loginhucrOpwG','cq5{Uq',2,'1980-11-10','+7(787)680-41-50'),(11,'Николаева Анна Тимуровна','loginAykjOzsT','Ol0`&U',3,'2002-05-19','+7(177)868-94-56'),(12,'Федотов Иван Артёмович','loginDXSHJSEh','(;Re5q',3,'1995-04-01','+7(133)067-44-52'),(13,'Смирнов Лев Маркович','loginLHqtkZus','m~f5QM',2,'1987-12-06','+7(104)296-41-35'),(14,'Грекова Ариана Никитична','logincNGcFsRb','|KsV84',3,'1970-01-05','+7(074)505-91-83'),(15,'Кузнецов Матвей Егорович','loginsjmmRZCV','N1r|=M',2,'1987-12-10','+7(970)343-68-57'),(16,'Орехов Марк Данилович','loginQktVVLNO','X=yXA2',3,'1980-03-15','+7(269)843-20-33'),(17,'Петрова В. Е.','loginSfSCNyis','Vks5I',2,'1976-03-05',''),(18,'Ефимова Марина Руслановна','loginSNuYRNyf','XzX22[',1,'1985-04-24','+7(006)637-83-97'),(19,'Кузьмин Давид Иванович','loginaaCzfbhM','>M}X9n',3,'1980-04-30','+7(306)392-88-06'),(20,'Румянцев Алексей Михайлович','loginaWWKiZpU','>7:#Ez',2,'1980-10-15','+7(141)119-28-48'),(21,'Беляева Полина Артёмовна','loginPglSNIWo','b&n1ID',3,'1996-11-16','+7(170)152-45-11'),(22,'Бородина Есения Тимофеевна','loginYdcGfWFO','5B=x;7',2,'1973-04-18','+7(413)195-24-65'),(23,'Степанов Артём Кириллович','loginnRPronjY','v/>!2C',1,'1980-02-24','+7(857)068-24-33'),(24,'Мартынова Мария Сергеевна','loginYdFSjJfD',':m@8Kr',2,'1988-01-12','+7(586)311-54-16'),(25,'Михайлов Илья Фёдорович','loginKhRzbQQc',']d9`.E',2,'1988-02-05','+7(798)532-01-90'),(26,'Панов Степан Елисеевич','loginziGKLHTL','>M}X9n',2,'1997-08-16','+7(720)164-53-59'),(27,'Денисов Даниил Васильевич','loginKerkuviW','jo=dJ1',3,'1989-05-14','+7(640)145-02-95'),(28,'Маркелова Асия Гордеевна','logingIjAzVqD','4Hnd.~',2,'2002-07-24','+7(261)699-89-60'),(29,'Богданова Екатерина Александровна','loginvNHJhdAf','}S9''/h',3,'1986-11-29','+7(166)530-51-19'),(30,'Пугачева Амелия Алексеевна','loginqRVDyqeG','g6:95H',3,'1976-03-05','+7(227)947-11-40'),(31,'Николаева Ксения Львовна','loginjqxLlerV','85:Uav',2,'1974-11-24','+7(203)368-97-45'),(32,'Березин Павел Егорович','loginfwQjrafc','6pQ>ct',3,'1979-03-29','+7(735)978-70-04'),(33,'Пономарев Ярослав Андреевич','loginDqTKhHHF','7b3^zP',1,'1974-08-06','+7(027)315-44-61'),(34,'Моисеева Ксения Фёдоровна','loginEXiCelOB','m$(X3^',3,'2002-12-21','+7(070)232-81-26'),(35,'Соколова Арина Арсентьевна','loginUcLIXlfr','nb(14R',3,'1983-09-13','+7(964)096-84-90'),(36,'Некрасов Владислав Егорович','logintapwUVVB','w3~;P}',3,'1971-05-18','+7(395)539-50-09'),(37,'Исаева София Александровна','loginIYWIabRI','D$!b8;',2,'1985-05-09','+7(327)557-44-35'),(38,'Петрова Алиса Андреевна','loginukYBtmrx',']3b0)I',3,'1982-12-18','+7(764)335-37-00'),(39,'Чеботарева Лейла Саввична','loginPZJcUzcE','O]y7wZ',1,'1996-03-01','+7(440)507-84-99'),(40,'Егорова Елизавета Константиновна','loginQaOpoeWc','\\1(kQd',3,'1988-11-16','+7(449)098-67-30'),(41,'Уваров Вячеслав Александрович','loginQXUudbyI','F+w2PR',3,'1981-07-09','+7(668)366-51-63'),(42,'Аникина Василиса Артёмовна','loginQeWeFzcY','Yl9>&''',3,'1977-06-05','+7(704)041-51-65'),(43,'Морозов Сергей Александрович','loginLlEZXZXY','Lvoq5$',2,'1987-08-12','+7(664)224-33-19'),(44,'Карасев Иван Владиславович','loginnCwWYALv','zb0hZ=',3,'1973-03-02','+7(550)144-94-91'),(45,'Васильев Степан Даниилович','loginAsFdWdsY','l''ZK4z',3,'1986-03-16','+7(430)058-69-09'),(46,'Андреева Полина Данииловна','loginQxmoBJyN','tGr82|',3,'1986-06-09','+7(543)635-10-02'),(47,'Евдокимова София Савельевна','loginuqzcxVBV','\\BSo~5',1,'1989-08-10','+7(621)226-66-62'),(48,'Иванова Виктория Евгеньевна','loginVxOIqFDq','A`||r4',3,'1977-09-04','+7(113)124-65-03'),(49,'Климова Любовь Львовна','loginSlHVgbpx','2e$1dL',1,'1976-06-18','+7(545)773-98-42'),(50,'Денисова Антонина Павловна','loginaNrXvJjT','\\8Egdt',2,'1997-03-11','+7(058)603-81-60'),(51,'Лебедев Артем Сергеевич','admin','admin',1,'2004-11-06','+7(999)999-99-99'),(52,'asdfsad asd asd ','asd','asd',2,'2023-04-29',''),(53,'asdfsad asd asd ','loginSLuyHpM','asd',2,'2023-04-29','+7(324)234 32-42'),(54,'Проверочный','','',NULL,'',''),(55,'Проверочнный','','',NULL,'',''),(56,'Еще один','','',NULL,'',''),(57,'Проверочный',NULL,NULL,2,NULL,NULL),(58,'вап','','',2,'',''),(59,'Дургого ','loginuWVqMcA','I8?tZp',2,'',''),(60,'другого клинета','loginSiVnfIR','KN%kq6',2,'',''),(61,'вапвапвр','','',2,'','');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

-- 
-- Definition of orders
-- 

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `id` int NOT NULL AUTO_INCREMENT,
  `iduser` int DEFAULT NULL,
  `order_date` varchar(45) NOT NULL,
  `date_receiving` varchar(45) NOT NULL,
  `costOrder` int NOT NULL,
  `idstaff` int DEFAULT NULL,
  `code` varchar(45) NOT NULL,
  `idpickuppoint` int DEFAULT NULL,
  `idstatus` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `gdg_idx` (`iduser`),
  KEY `sdaasd_idx` (`idpickuppoint`),
  KEY `fhggf_idx` (`idstatus`),
  KEY `zdvv_idx` (`idstaff`),
  CONSTRAINT `fhggf` FOREIGN KEY (`idstatus`) REFERENCES `statusorder` (`id`),
  CONSTRAINT `gdg` FOREIGN KEY (`iduser`) REFERENCES `user` (`id`),
  CONSTRAINT `sdaasd` FOREIGN KEY (`idpickuppoint`) REFERENCES `pickuppoint` (`id`),
  CONSTRAINT `zdvv` FOREIGN KEY (`idstaff`) REFERENCES `user` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb3;

-- 
-- Dumping data for table orders
-- 

/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders`(`id`,`iduser`,`order_date`,`date_receiving`,`costOrder`,`idstaff`,`code`,`idpickuppoint`,`idstatus`) VALUES(14,51,'2023-05-25','2023-05-31',3881,NULL,'958',1,NULL),(17,51,'2023-05-25','2023-05-31',3881,NULL,'958',1,NULL),(25,51,'2023-05-25','2023-05-31',3881,NULL,'576',1,4),(26,51,'2023-05-25','2023-05-31',3881,NULL,'576',1,3),(27,51,'2023-05-25','2023-05-26',3881,NULL,'576',1,1),(32,51,'2023-05-25','2023-05-26',3881,NULL,'285',2,1),(33,51,'2023-05-25','2023-05-31',3881,NULL,'285',2,5),(37,51,'2023-05-25','2023-05-31',3881,NULL,'798',1,6),(38,51,'2023-05-25','2023-05-31',56957,NULL,'598',7,NULL),(39,51,'2023-05-25','2023-05-28',62734,NULL,'130',7,2),(40,51,'2023-05-25','2023-05-28',73144,NULL,'227',7,NULL),(41,51,'2023-05-25','2023-05-31',17847,NULL,'665',1,NULL),(42,51,'2023-05-25','2023-05-31',10534,NULL,'144',1,NULL),(43,51,'2023-05-25','2023-05-31',12772,NULL,'815',7,NULL),(44,51,'2023-05-25','2023-05-31',24350,NULL,'520',7,NULL),(45,51,'2023-05-25','2023-05-28',820,NULL,'863',1,NULL),(46,51,'2023-05-25','2023-05-28',496,NULL,'770',1,NULL),(50,51,'2023-05-25','2023-05-28',1636,NULL,'156',7,2),(53,51,'2023-05-25','2023-05-28',1679,NULL,'945',7,NULL),(54,51,'2023-05-25','2023-05-28',11965,NULL,'313',7,NULL),(55,51,'2023-05-25','2023-05-28',13193,NULL,'527',2,NULL),(56,56,'2023-05-25','2023-05-27',29084,NULL,'928',2,1),(57,51,'2023-05-27','2023-06-02',14171,NULL,'0',2,1),(58,54,'2023-05-27','2023-05-30',24105,51,'0',8,1),(59,59,'2023-05-28','2023-06-03',18494,NULL,'0',1,1),(60,60,'2023-05-28','2023-06-03',27094,NULL,'0',8,1),(61,61,'2023-05-28','2023-06-03',17847,NULL,'0',3,1);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;

-- 
-- Definition of ordersstructure
-- 

DROP TABLE IF EXISTS `ordersstructure`;
CREATE TABLE IF NOT EXISTS `ordersstructure` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idorders` int NOT NULL,
  `idproduct` varchar(100) NOT NULL,
  `countProduct` int NOT NULL,
  `costProduct` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fds_idx` (`idorders`),
  KEY `weer_idx` (`idproduct`),
  CONSTRAINT `asdas` FOREIGN KEY (`idproduct`) REFERENCES `product` (`articule`),
  CONSTRAINT `fds` FOREIGN KEY (`idorders`) REFERENCES `orders` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8mb3;

-- 
-- Dumping data for table ordersstructure
-- 

/*!40000 ALTER TABLE `ordersstructure` DISABLE KEYS */;
INSERT INTO `ordersstructure`(`id`,`idorders`,`idproduct`,`countProduct`,`costProduct`) VALUES(8,14,'10516469',1,'3881'),(9,17,'10516469',1,'3881'),(10,25,'10516469',1,'3881'),(11,26,'10516469',1,'3881'),(12,27,'10516469',1,'3881'),(13,32,'10516469',1,'3881'),(14,33,'10516469',1,'3881'),(15,37,'10516469',1,'3881'),(16,38,'11772501',2,'18492'),(17,38,'10516469',1,'3881'),(18,38,'147951219',2,'34584'),(19,39,'10516469',1,'3881'),(20,39,'11772501',1,'9246'),(21,39,'147951219',1,'17292'),(22,39,'18001852',2,'6572'),(23,39,'67526566',3,'14100'),(24,39,'4790772',3,'11643'),(25,40,'11772501',2,'18492'),(26,40,'147951219',2,'34584'),(27,40,'18001852',2,'6572'),(28,40,'67526566',2,'9400'),(29,40,'4790772',1,'3881'),(30,40,'dfg',5,'215'),(31,41,'10589463',1,'17847'),(32,42,'10516377',1,'1288'),(33,42,'11772501',1,'9246'),(34,43,'11772501',1,'9246'),(35,43,'10516377',1,'1288'),(36,43,'139370370',1,'2238'),(37,44,'10516469',1,'3881'),(38,44,'10516377',1,'1288'),(39,44,'11772501',1,'9246'),(40,44,'141009593',1,'7697'),(41,44,'139370370',1,'2238'),(42,45,'dfg',4,'172'),(43,45,'fdg34',2,'648'),(44,46,'fdg34',1,'324'),(45,46,'dfg',4,'172'),(46,50,'95658230',1,'1140'),(47,50,'dfg',4,'172'),(48,50,'fdg34',1,'324'),(49,53,'dfg',5,'215'),(50,53,'fdg34',1,'324'),(51,53,'95658230',1,'1140'),(52,54,'dfg',3,'129'),(53,54,'95658230',1,'1140'),(54,54,'fdg34',4,'1296'),(55,54,'67526566',2,'9400'),(56,55,'10516469',3,'11643'),(57,55,'dfg',2,'86'),(58,55,'fdg34',1,'324'),(59,55,'95658230',1,'1140'),(60,56,'10516469',7,'27167'),(61,56,'dfg',3,'129'),(62,56,'95658230',1,'1140'),(63,56,'fdg34',2,'648'),(64,57,'16300196',1,'8506'),(65,57,'18001852',1,'3286'),(66,57,'151299335',1,'2379'),(67,58,'10516469',5,'19405'),(68,58,'67526566',1,'4700'),(69,59,'11772501',2,'18494'),(70,60,'11772501',1,'9247'),(71,60,'10589463',1,'17847'),(72,61,'10589463',1,'17847');
/*!40000 ALTER TABLE `ordersstructure` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2023-05-29 12:50:44
-- Total time: 0:0:0:0:190 (d:h:m:s:ms)
