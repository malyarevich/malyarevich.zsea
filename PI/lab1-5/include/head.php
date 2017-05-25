   <head>
      <meta charset="utf-8">
      <meta http-equiv="X-UA-Compatible" content="IE=edge">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <meta name="description" content="">
      <meta name="author" content="">
      <link rel="shortcut icon" href="../../assets/ico/favicon.ico">
      <title><?php echo $page?></title>
      <script src="./js/jquery-3.2.1.min.js"></script>
      <!-- Bootstrap core CSS -->
      <link href="css/bootstrap.min.css" rel="stylesheet">
      <script src="js/bootstrap.js" type="text/javascript"></script>
      <!-- Custom styles for this template -->
      <link href="jumbotron-narrow.css" rel="stylesheet">
	    	 	      	 	 	  	<link rel="stylesheet" type="text/css" href=" <?php
    require_once 'dbconnect.php'; 
         
	if (!(empty($_COOKIE)))
	{
		$query = mysqli_query($link1, "SELECT design FROM users WHERE ID = ".$_COOKIE["id"].";");
		$rec_design = mysqli_fetch_assoc($query) or die("Error");
	   
		echo $rec_design['design'];
	}
	?> ">
	
      <?php

         if(! $_COOKIE || $_COOKIE["id"] == -1)
         {
         header("Location: index.php"); 
         exit();
         }
         
         $query = mysqli_query($link1, "SELECT * FROM users WHERE ID = '".$_COOKIE["id"]."';");
         
         $data = mysqli_fetch_assoc($query);
         
         
         
         
         ?>
   </head>