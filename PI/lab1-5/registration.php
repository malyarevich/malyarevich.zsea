<html lang="en">
<?php
	$page = "Registration";
	include ("./include/head.php");
?>
   <body>
      <?php

         
         
         if(!(empty($_COOKIE))) {
			echo "<script> console.log(" . $_COOKIE["id"] . ")</script>";
			if ($_COOKIE["id"]  > 0)
               {
               	   header("Location: ./index.php");
               }
         }
         
         ?>
      <div class="container">
     <?php include ("./include/nav.php");?>
      
      <form method="POST" enctype="multipart/form-data">
         <div class="row marketing  text-center">
            <div class="col-lg-4" >
               <label class="control-label" for="inputEmail">Email</label>
               <div class="form-group">
                  <input type="text" name="email" id="inputEmail" placeholder="Email"  class="form-control"  value="<?php if(isset($_POST["email"])) { echo $_POST["email"]; } ?>">
               </div>
               <label class="control-label" for="inputYourName">Name</label>
               <div class="form-group">
                  <input type="text" name="name" id="inputYourName"  class="form-control" placeholder="Name" value="<?php if(isset($_POST["name"])) { echo $_POST["name"]; } ?>">
               </div>
               <label class="control-label" for="inputnickname">Nickname</label>
               <div class="form-group">
                  <input type="text" name="nickname" id="inputEmail"  class="form-control" placeholder="Nickname" value="<?php  if(isset($_POST["nickname"])) { echo $_POST["nickname"]; } ?>">
               </div>
            </div>
            <div class="col-lg-4">
               <label class="control-label" >About you</label>
               <div class="form-group">
                  <textarea type="text" id="inputQuestion"  class="form-control" name="question" rows="8" cols="40" ><?php  if(isset($_POST["question"])) { echo $_POST["question"]; } ?></textarea>
               </div>
            </div>
            <div class="col-lg-4">
               <label class="control-label" for="inputPassword">Password</label>
               <div class="controls">
                  <input type="password" id="inputPassword" class="form-control" name="password" placeholder="Password" value="<?php if(isset($_POST["password"])) { echo $_POST["password"]; }?>">
               </div>
               </br> </br>
               <h4>Upload picture</h4>
               <span class="btn btn-default btn-file">
               Browse <input type="file" name = "filename">
               </span>
            </div>
            <div class="col-lg-12">
               <div class="form-group">
                  <button type="submit" class="btn btn-primary btn-lg">Sign Up</button>
               
                    <?php include 'check_registrations_data.php'	   ?>
                 
               </div>
            </div>
      </form>
      </div>
      <div class="footer">
         <p>&copy; Company 2017</p>
      </div>
   </body>
</html>