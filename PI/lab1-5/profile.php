<html lang="en">

<?php
	$page = "Profile";
	include ("./include/head.php");
?>
   <body>
      <div class="container">
      
         <?php include ("./include/nav.php");?>
	   <div class="col-lg-12 text-center" >
	  		 	  <form name="myFormDesign" action="change_design.php" method="post" enctype="multipart/form-data" >
	  
	    <button type="submit" name = "blue" class="btn btn-primary btn-sm">Blue</button>
  <button type="submit" name = "green" class="btn btn-success btn-sm">Green</button>
    <button type="submit" name = "red" class="btn btn-danger btn-sm">Red</button>
	  </form>
	   </br></br>
	   </div>
      <form name="myForm" action="update.php" method="post" enctype="multipart/form-data" >
         <div class="row marketing  text-center">

            <div class="col-lg-4" >
               <label class="control-label" for="inputEmail">Email</label>
               <div class="form-group">
                  <input type="text" name="email" id="inputEmail" placeholder="Email"  class="form-control"  value="<?php echo $data['email']; ?>">
               </div>
			   </br>
               <label class="control-label" for="inputYourName">Name</label>
               <div class="form-group">
                  <input type="text" name="name" id="inputYourName"  class="form-control" placeholder="Name" value="<?php echo $data['name']; ?>">
               </div>
          
            </div>
            <div class="col-lg-4">
               <label class="control-label" >About you</label>
               <div class="form-group">
                  <textarea type="text" id="inputQuestion"  class="form-control" name="question" rows="8" cols="40" ><?php echo $data['information']; ?></textarea>
               </div>
            </div>
            <div class="col-lg-4">
               <img src="<?php echo $data['path']; ?>"  width="150" height="150" alt="alt for avatar"></img>
               </br>
               <h4>Upload picture</h4>
               <span class="btn btn-default btn-file">
               Browse <input type="file" name = "filename">
               </span>
            </div>
            </br>
            <button type="submit" class="btn btn-primary btn-lg">Save</button>
      </form>
	 

      </div>
      <div class="footer">
         <p>&copy; Company 2017</p>
      </div>
   </body>
</html>