<!DOCTYPE html>
<html lang="en">

<?php
	$page = "Administration";
	include ("./include/head.php");
?>
   <body>
      <?php
         if(! $_COOKIE)
         {
         header("Location: index.php"); 
         exit();
         }
         
         
         
         if($_COOKIE["role"] != 1)
         {
          header("Location: index.php"); 
         exit();
         }
         
         
         ?>
      <div class="container">
         
         <?php 
		 $page = "Administration Block";
		 include ("./include/nav.php");?>
		 
         <form name="myForm" action="administration/administration_buttons.php" method="post" enctype="multipart/form-data" >
            <div class="row marketing">
               <div class="col-lg-6  col-md-6 col-sm-6 col-xs-6">
                  <button type="submit" name="del_users" class="btn btn-danger btn-cs">Delete all users</button> 
               </div>
               <div class="col-lg-6 text-right col-md-6 col-sm-6 col-xs-6">
                  <button type="submit" name="del_messages" class="btn btn-danger btn-cs">Delete all messages from guestbook</button> 
               </div>
               <?php include 'administration_features.php'	   ?>
         </form>
         </div>
         <div class="footer">
            <p>&copy; Company 2017</p>
         </div>
      </div>
   </body>
</html>