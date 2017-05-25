<?php
require_once("dbconnect.php");

if (isset($_POST['add_article'])) {
    
    if ($_POST) {
        $article = $_POST["editor1"];
        
        mysqli_query($link1, "INSERT INTO articles (text, date) VALUES ('$article', NOW())") or die("Query failed!");
        
        Header("Location: ./Content.php");
        
    }
    
}

if (isset($_POST['delete_all'])) {
    mysqli_query($link1, "truncate articles") or die("Query failed!");
    
    Header("Location: ./Content.php");
}

if (isset($_POST['del_article'])) {
    
    if ($_POST) {
        $date = $_POST["date"];
        echo $date;
        mysqli_query($link1, "DELETE FROM articles WHERE date = '$date'") or die("Query failed del");
        
        Header("Location: ./Content.php");
    }
}
if (isset($_POST['upd_article'])) {
    
    if ($_POST) {
        
        $date  = $_POST["date"];
        $query = mysqli_query($link1, "SELECT text,date FROM articles WHERE date = '$date';");
        
        $data = mysqli_fetch_assoc($query);
?>
		   
		   
		   <!DOCTYPE html>
<html>
  <head>
    <title>Update</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
	  	 <script src="ckeditor/ckeditor.js"></script>
		       <link href="css/list.css" rel="stylesheet" media="screen">
			    <style>
   .container {
    margin-top: 10%; /* Отступ сверху */
   }
  </style>
  </head>
  <body>
    <form name="myForm" action="work_with_articles.php" method="post" onSubmit="return splash();">
		<div class="container">
	<div class="row">
	 <textarea name="editor2" id="editor2" rows="10" cols="80">
                  <?php
        echo $data['text'];
?>
            </textarea>
			    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
				</br>
				  <button type="submit" name="upd" class="btn btn-success btn-lg">Update</button>
	
			  </div>
			    <div class="col-lg-6 text-right col-md-6 col-sm-6 col-xs-6">
				    <textarea name="date2" readonly rows="1" name="date">     <?php  echo $data['date'];  ?> </textarea>
			    </div>
			  </div>
			   </div>
			  </form>
	
	     <script>
                CKEDITOR.replace( 'editor2' );
            </script>
    <script src="http://code.jquery.com/jquery-latest.js"></script>
    <script src="js/bootstrap.min.js"></script>
  </body>
</html>

<?php
    }
}

if (isset($_POST['upd'])) {
    if ($_POST) {
        $article_upd = $_POST["editor2"];
       $date = $_POST["date2"];
    
        
        mysqli_query($link1, "UPDATE articles
		   SET text = '$article_upd'
		   WHERE date = '$date'
		   ");
        
       Header("Location: ./Content.php");
        
    }
}

?>
