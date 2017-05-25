<!DOCTYPE html>
<html lang="en">
<?php
	$page = "Sign In";
	include ("./include/head.php");
?>
   <body>
      <?php
         
         
         if(!(empty($_COOKIE)))
         {
         if ($_COOKIE["id"]  > 0)
               {
               	   header("Location: index.php");
               }
         }
         
         ?>
      <div class="container">

	  <?php 
	  
		include ("./include/nav.php");?>
         <form action='actions_after_login.php' method=post>
            <div class="row marketing">
               <div class="col-lg-12">
                  <div class="form-group">
                     <label for="nickname">Nickname:</label>
                     <input type="text" class="form-control" name="nickname" placeholder="Nickname" >
                  </div>
               </div>
               <div class="col-lg-12">
                  <div class="form-group">
                     <label for="pwd">Password:</label>
                     <input type="password" name="password" placeholder="Password" class="form-control" id="pwd">
                  </div>
               </div>
            </div>
            <button type="submit" name="submit" class="btn btn-primary btn-lg">Sign in</button>
         </form>
         <div class="footer">
            <p>&copy; Company 2017</p>
         </div>
      </div>
   </body>
</html>