<?php
require_once 'dbconnect.php';
include 'profile.php';
    $p = $_COOKIE["id"];
	
if (isset($_POST['blue'])) {
	$query = "
		UPDATE users
		SET design = 'css/design_blue.css'
		WHERE ID = $p; ";
}

if (isset($_POST['green'])) {
	$query = "
		UPDATE users
		SET design = 'css/design_green.css'
		WHERE ID = $p; ";
}


if (isset($_POST['red'])) {
	$query = "
		UPDATE users
		SET design = 'css/design_red.css'
		WHERE ID = $p; ";
      
}/*

   $mysqli = new mysqli(HOST, MYSQL_USER, MYSQL_PASS, DATABASE);
var_dump( query );
die;*/

	$mysqli = new mysqli(HOST, MYSQL_USER, MYSQL_PASS, DATABASE); 

	if (mysqli_connect_errno()) { 
		printf("Подключение невозможно: %s\n", mysqli_connect_error()); 
		exit(); 
	} 
	
	$stmt = $mysqli->prepare($query) or die("Query failed!");
	$stmt->bind_param("s", $code); 
	$code = "C%"; 

	$stmt->execute(); 
	Header("Location: ./profile.php");

?>