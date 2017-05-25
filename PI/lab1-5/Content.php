<!DOCTYPE html>
<html lang="en">

<?php
	$page = "Articles";
	include ("./include/head.php");
?>
   <body>
      <?php
         if (!(empty($_COOKIE)))
         {
         $query = "SELECT nickname FROM users WHERE ID = '".$_COOKIE["id"]."' AND user_hash = '".$_COOKIE['hash']."' ;";
         $zapros2 = mysqli_query($link1, $query) or die ("Error");
         }
         
         
         ?>
      <div class="container">
         <?php 
		 include ("./include/nav.php");?>
         
         <div class="row marketing">
            <div class="col-lg-12">
               <?php
                  $r = mysqli_query($link1, "SELECT * FROM articles ORDER BY date DESC") or die('Error'); 
                               while ($row = mysqli_fetch_array($r)) 
                                   {
                     
                     		   ?>
               <form name="myForm" action="work_with_articles.php" method="post" onSubmit="return splash();">
                  <div class="well col-lg-12">
                     <div class="page-header">
                        <?php  echo $row['text'];  ?>
                     </div>
                     <textarea readonly rows="1" name="date">     <?php  echo $row['date'];  ?> </textarea>
                     <?php 
                        if (!empty($_COOKIE))
                                 {
                                 $query = mysqli_query($link1, "SELECT role FROM users WHERE ID = '".$_COOKIE["id"]."';");
                                       
                                       $data = mysqli_fetch_assoc($query);
                                 
                                  if($data["role"] == 1) { ?>
                     <button type="submit" name="del_article" class="btn btn-default btn-xs">Delete</button>
                     <button type="submit" name="upd_article" class="btn btn-default btn-xs">Update</button>
               </form>
               <?php } }?>
               </div>
               <?php
                  }
                  if (!empty($_COOKIE))
                  {
                  $query = mysqli_query($link1, "SELECT role FROM users WHERE ID = '".$_COOKIE["id"]."';");
                  
                  $data = mysqli_fetch_assoc($query);
                  
                  if($data["role"] == 1) {
                      echo '
                  <form name="myForm" action="work_with_articles.php" method="post" onSubmit="return splash();">
                  <textarea name="editor1" id="editor1" rows="10" cols="80">
                  This is my textarea to be replaced with CKEditor.
                  </textarea>
                  <br>
                  <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                  <button type="submit" name="add_article" class="btn btn-success btn-lg">Submit</button>
                  </div>
                  <div class="col-lg-6 text-right col-md-6 col-sm-6 col-xs-6">
                  <button type="submit" name="delete_all" class="btn btn-danger btn-lg">Delete all articles</button>
                  </div>
                  </form>
                  ';
                  }
                  }
                  
                  
                  ?>
               <script>
                  // Replace the <textarea id="editor1"> with a CKEditor
                  // instance, using default configuration.
                  /*CKEDITOR.replace( 'editor1' );*/
               </script>
            </div>
         </div>
         <div class="footer">
            <p>&copy; Company 2017</p>
         </div>
      </div>
   </body>
</html>