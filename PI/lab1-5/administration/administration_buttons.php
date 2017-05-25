<?php
require_once("dbconnect.php");



if (isset($_POST['del_users'])) {
    
    mysqli_query($link1, "DELETE FROM users WHERE role != 1") or die('Error deleting');
	 mysqli_query($link1,"truncate gb") or die('Error deleting');
}

if (isset($_POST['del_messages'])) {
    
    
    
    mysqli_query($link1, "truncate gb") or die('Error deleting');
    
    
}


if (isset($_POST['Delete_user'])) {
    
    if ($_POST) {
        $delId = $_POST["id"];
        
        mysqli_query($link1, "DELETE FROM users WHERE ID= $delId AND role != 1") or die("Query failed del");
        mysqli_query($link1, "DELETE FROM gb WHERE user_id = $delId") or die("Query failed del");
		
		
        
        
        
    }
    
}

if (isset($_POST['Update_user'])) {
    
    
    
    if ($_POST) {
        $error          = "";
        $updid          = $_POST["id"];
        $updnickname    = $_POST["nickname"];
        $updemail       = $_POST["email"];
        $updpassword    = $_POST["password"];
        $updrealname    = $_POST["name"];
        $updpath        = $_POST["path"];
        $updinformation = $_POST["information"];
        
        
        if(strlen($updpassword) >= 4)
        {
			echo $updpassword;
        $updpassword = md5(md5(trim($_POST['password'])));
        mysqli_query($link1, "
		UPDATE users
          SET PASSWORD = '$updpassword'
		  WHERE ID=$updid") or die("Query failed");
         }
        
        
        if ($_POST['ban'] == 1) {
            $updBan = 1;
        } else {
            $updBan = 0;
        }
        
        if ($_POST['role'] == 1) {
            $updrole = 1;
        } else {
            $updrole = 0;
        }
        
        if (strlen($updrealname) == 0 || strlen($updrealname) >= 20) {
            $error .= "Enter correct name<br>";
        }
        if (strlen($updnickname) == 0 || strlen($updnickname) >= 20) {
            $error .= "Enter correct nickname<br>";
            
        }
        if (strlen($updinformation) == 0 || strlen($updinformation) >= 20) {
            $error .= "Enter correct information<br>";
            
        }
        
        
        if ($error == "") {
            
            
            
            $sql1 = "UPDATE users
   SET  name = '$updrealname',
   information = '$updinformation',
   email = '$updemail',
   nickname = '$updnickname',
   path = '$updpath'
   WHERE ID=  '" . mysqli_real_escape_string($link1, $updid) . "' LIMIT 1";
            mysqli_query($link1, $sql1) or die("Query failed upd users");
            
            $sql = "UPDATE gb
	      SET path = '$updpath', nickname='$updnickname'
		WHERE user_id = $updid;";
            $r = mysqli_query($link1, $sql) or die("Query failed");
            
            header("Location: http://localhost/MySite/administration_block.php");
            
        } else {
            echo $error;
        }
    }
    
    
}

if (isset($_POST['lock_button'])) {
    
    $updid = $_POST["id"];
    
    $query = mysqli_query($link1, "SELECT ban, role FROM users WHERE ID ='" . mysqli_real_escape_string($link1, $updid) . "' LIMIT 1");
    
    $data = mysqli_fetch_assoc($query);
    
    if ($data["ban"] == 0) {
        $sql = "UPDATE users
	      SET ban = 1
		 WHERE 
		 ban != 1 AND 
		 role != 1 AND
		 ID='" . mysqli_real_escape_string($link1, $updid) . "' LIMIT 1";
        $r = mysqli_query($link1, $sql) or die("Query failed");
    } else {
        $sql = "UPDATE users
	      SET ban = 0
		 WHERE 
		 ban != 0 AND 
		 role != 1 AND
		 ID ='" . mysqli_real_escape_string($link1, $updid) . "' LIMIT 1";
        $r = mysqli_query($link1, $sql) or die("Query failed");
    }
    
}

if (isset($_POST['access_button'])) {
    
    $updid = $_POST["id"];
    
    $query = mysqli_query($link1, "SELECT ban, role FROM users WHERE ID ='" . mysqli_real_escape_string($link1, $updid) . "' LIMIT 1");
    
    $data = mysqli_fetch_assoc($query);
    
    if ($data["role"] == 0) {
        $sql = "UPDATE users
	      SET role = 1
		 WHERE 
		 ID='" . mysqli_real_escape_string($link1, $updid) . "' LIMIT 1";
        $r = mysqli_query($link1, $sql) or die("Query failed");
    } else {
        $sql = "UPDATE users
	      SET role = 0
		 WHERE 
		 ID != 1 AND
		 ID ='" . mysqli_real_escape_string($link1, $updid) . "' LIMIT 1";
        $r = mysqli_query($link1, $sql) or die("Query failed");
    }
    
}
header("Location: http://localhost/MySite/administration_block.php");



?>