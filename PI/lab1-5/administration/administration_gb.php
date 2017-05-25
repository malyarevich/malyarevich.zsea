<?php
require_once("dbconnect.php");

$id            = $_POST['mes_id'];
$user_nickname = $_POST['user_nickname'];


if (isset($_POST['del_button'])) {
    
    mysqli_query($link1, "DELETE FROM gb WHERE id = $id") or die('Error deleting');
}

if (isset($_POST['lock_button'])) {
    
    
    $query = mysqli_query($link1, "SELECT * FROM users WHERE nickname='" . mysqli_real_escape_string($link1, $user_nickname) . "' LIMIT 1");
    
    $data = mysqli_fetch_assoc($query);
    
    if ($data["ban"] == 0) {
        $sql = "UPDATE users
	      SET ban = 1
		 WHERE 
		 ban != 1 AND 
		 role != 1 AND
		 nickname='" . mysqli_real_escape_string($link1, $user_nickname) . "' LIMIT 1";
        $r = mysqli_query($link1, $sql) or die("Query failed");
    } else {
        $sql = "UPDATE users
	      SET ban = 0
		 WHERE 
		 ban != 0 AND 
		 role != 1 AND
		 nickname='" . mysqli_real_escape_string($link1, $user_nickname) . "' LIMIT 1";
        $r = mysqli_query($link1, $sql) or die("Query failed");
    }
    
}



header("Location: http://localhost/MySite/guestbook.php");
?>