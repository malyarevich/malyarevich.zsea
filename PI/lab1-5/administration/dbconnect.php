<?php
      
	  
        
        // название  сервера БД
   define ("HOST", "localhost");
   // название базы данных
   define ("DATABASE", "phpmyadmin");
   // пользователь MySQL
   define ("MYSQL_USER", "root");
   // пароль к MYSQL
   define ("MYSQL_PASS", "");
   
   
   // создаем базу данных и таблицу  gb
   $link1=mysqli_connect(HOST, MYSQL_USER, MYSQL_PASS) or die("Нет соединения с MySQL сервером!");
   $result= mysqli_query($link1,"CREATE DATABASE IF NOT EXISTS ".DATABASE) or die ("Не могу создать базу данных gb.");
   mysqli_select_db($link1, DATABASE) or die("Нет содениения с требуемой базой данных!");
   mysqli_query ($link1, "CREATE TABLE IF NOT EXISTS gb (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, user_id int, nickname VARCHAR (100), path VARCHAR (100), dt DATETIME, msg TEXT)") or die ("Не могу создать таблицу gb.");
   mysqli_query ($link1, "create table IF NOT EXISTS users(
   ID int NOT NULL AUTO_INCREMENT,
   email varchar(50) NOT NULL,
   name varchar(20),
   information varchar(255),
   nickname varchar(20),
   path varchar(255),
   role BOOL NOT NULL DEFAULT '0',
   ban BOOL NOT NULL DEFAULT '0',
   IP_ADDRESS varchar(50),
   PASSWORD varchar(50),
   user_hash varchar(32),
   design BLOB,
   PRIMARY KEY (ID)
   );") or die ("Не могу создать таблицу gb.");
      mysqli_query ($link1, "create table IF NOT EXISTS articles(
   ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
   text  BLOB,
   date DATETIME
   );") or die ("Не могу создать таблицу text.");
   
   	    $sql = "UPDATE users
	      SET role = 1
		WHERE ID = 1;";
    $r = mysqli_query($link1, $sql) or die("Query failed!");
	
	
	function get_ip()
{
    if (!empty($_SERVER['HTTP_CLIENT_IP']))
    {
        $ip=$_SERVER['HTTP_CLIENT_IP'];
    }
    elseif (!empty($_SERVER['HTTP_X_FORWARDED_FOR']))
    {
        $ip=$_SERVER['HTTP_X_FORWARDED_FOR'];
    }
    else
    {
        $ip=$_SERVER['REMOTE_ADDR'];
    }
    return $ip;
}

        // список разрешенных IP адресов через пробел
        $allowed_ips = "::1";
		
		

   ?>