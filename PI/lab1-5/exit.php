<?php 

   setcookie("id", "", time() - 3600);
    
    setcookie("nickname", "", time() - 3600);
    
	 setcookie("role", "", time() - 3600);
	
    setcookie("hash", "", time() - 3600);

	 header("Location: index.php"); 
	 exit();

?>