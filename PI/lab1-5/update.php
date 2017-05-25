<?php

require_once 'dbconnect.php';
include 'profile.php';

$error = "";

$email    = $_POST["email"];
	$result_email = filter_var($email, FILTER_VALIDATE_EMAIL);
$realname = $_POST["name"];




$question = $_POST["question"];


if ($_FILES) {
    $path = "avatars/" . $_FILES["filename"]["name"];
}

 if (strlen($result_email) == 0) {
        $error .= "Enter correct e-mail<br>";
    }
    if (strlen($realname) == 0 || strlen($realname) >= 20) {
        $error .= "Enter correct name<br>";
    }


    if (strlen($question) == 0 || strlen($question) >= 220) {
        $error .= "Enter information about yourself";
    }
    if ($_FILES["filename"]["size"] > 1024 * 3 * 1024) {
        $error .= "File size exceeds 3 megabytes";
        exit;
    }
	



if ($_FILES) {
    if (!copy($_FILES["filename"]["tmp_name"], "avatars/" . $_FILES["filename"]["name"])) {
        
             $error .= "Error loading file";
    }
}

if ($error == "") {
    
    $p = $data['ID'];
    

    $query2 = "
   UPDATE users
   SET email = '$email',
   name = '$realname',
   information = '$question', 
   path = '$path'
   WHERE ID = $p; ";
    $res = mysqli_query($link1, $query2) or die("Query failed!");
    
   $sql = "UPDATE gb
	      SET path = '$path'
		WHERE user_id = $p;";
    $r = mysqli_query($link1, $sql) or die("Query failed");
    

    Header("Location: http://localhost/MySite/profile.php");
    
    
    
} else {
    echo $error;
}



?>
