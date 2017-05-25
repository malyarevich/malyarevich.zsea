<?php

require_once 'dbconnect.php';

$error = "";
if ($_POST) {
    $email    = $_POST["email"];
	$result_email = filter_var($email, FILTER_VALIDATE_EMAIL);
    $realname = $_POST["name"];
    $nickname = $_POST["nickname"];
	$ip = get_ip();

    $password = $_POST['password'];

    $question = $_POST["question"];

    $path     = "avatars/" . $_FILES["filename"]["name"];
	
	$opt = array(
  'flags' => 'FILTER_FLAG_IPV4'
);
$result_ip = filter_var($ip, FILTER_VALIDATE_IP, $opt);

   if (strlen($result_ip) == 0) {
        $error .= "Error<br>";
    }
    
    if (strlen($result_email) == 0) {
        $error .= "Enter correct e-mail<br>";
    }
    if (strlen($realname) == 0 || strlen($realname) >= 45) {
        $error .= "Enter correct name<br>";
    }
    if (strlen($nickname) == 0 || strlen($nickname) >= 20) {
        $error .= "Enter correct nickname<br>";
        
    }

    if (!preg_match("/^[a-zA-Z0-9]+$/", $_POST["nickname"])) {
        $error .= "Login must contain only english letters<br>";
        
    } 
	
	
 /*   $query = mysqli_query($link1, "SELECT COUNT(ID) FROM users WHERE nickname='" . mysqli_real_escape_string($_POST["nickname"]) . "'");
    if (mysql_result($query, 0) > 0) {
        
        $error .= "Try a new login";
        
    }*/
    if (strlen($password) == 0) {
        $error .= "Enter your password<br>";
    } elseif (strlen($password) < 4) {
        $error .= "Password is too short. Enter correct password.<br>";
    }
    if (strlen($question) == 0 || strlen($question) >= 220) {
        $error .= "Enter information about yourself";
    }
    if ($_FILES["filename"]["size"] > 1024 * 3 * 1024) {
        $error .= "File size exceeds 3 megabytes";
        exit;
    }
    
    $password = md5(md5(trim($_POST['password'])));
    
    if (!copy($_FILES["filename"]["tmp_name"], "avatars/" . $_FILES["filename"]["name"])) {
        $error .= "Error loading file";
    }
	
	
}


if ($error == "" && $_POST) {



 

    $query = "INSERT INTO users (email, name,information, nickname, path, IP_ADDRESS, PASSWORD, design
) VALUES ('$email', 
            '$realname','$question','$nickname', '$path', '$ip', '$password', 'css/design_blue.css' )";
    $res = mysqli_query($link1, $query) or die("Query failed!");
	
	
	
    
    setcookie("id", "", time() - 3600);
    
    setcookie("nickname", "", time() - 3600);
    
	 setcookie("role", "", time() - 3600);
	
    setcookie("hash", "", time() - 3600);
    Header("Location: index.php");
    
    
    
} else {
    echo $error;
}



?>
