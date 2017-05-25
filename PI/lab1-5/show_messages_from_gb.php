<!DOCTYPE html>
<html>
  <head>
    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen">
	<link rel="stylesheet" type="text/css" href=" <?php
    require_once 'dbconnect.php'; 
         
         if (!(empty($_COOKIE)))
         {
        $query = mysqli_query($link1, "SELECT design FROM users WHERE ID = '".$_COOKIE["id"]."' ;");
		   $rec_design = mysqli_fetch_assoc($query) or die("Error");
		   
		   echo $rec_design['design'];
         }
         
         
         ?>    ">
  </head>
  <body>
      <?php
            $c = 0;
            $r = mysqli_query($link1, "SELECT * FROM gb ORDER BY dt DESC") or die('Error'); // выбор всех записей из БД, отсортированных так, что самая последняя отправленная запись будет всегда первой.
            while ($row = mysqli_fetch_array($r)) // для каждой записи организуем вывод.
                {					

                if ($c % 2)
                    $col = "color='#f9f9f9'"; // цвет для четных записей
                else
                    $col = "color='#f0f0f0'"; // цвет для нечетных записей
                
				$query2 = mysqli_query($link1, "SELECT * FROM users WHERE id='" . $row['id'] . "' LIMIT 1");
				$data2  = mysqli_fetch_assoc($query2);
				
            ?>
         <form name="myForm" action="administration/administration_gb.php" method="post" enctype="multipart/form-data" >
		 <hr>
			<div class="panel panel-default" <?php echo $col; ?>>
				<div class="panel-heading" style="display: block; height:150px;">
					<div class="col-xs-7 col-md-3 col-lg-4"  style="display: block;">Nick: <?php echo $data2['nickname']; ?></div> 
                    <?php
                        if (!(empty($_COOKIE)) && $_COOKIE["role"] == 1) {
						
                            if ($data2["ban"] == 0) {
                                echo '<button type="submit" name="lock_button" class="btn btn-primary btn-xs">Lock</button> ';
                            } else {
                                echo '<button type="submit" name="lock_button" class="btn btn-danger btn-xs">Unlock</button> ';
                            }
                            
                        }
                        
					?>
					<div class="col-xs-7 col-md-3 col-lg-4" style="display: block;">Date: <?php
						 echo $row['dt'];
						 if (!(empty($_COOKIE)) && $_COOKIE["role"] == 1) {
						 ?>
						 <div><?php
							echo $data2['id'];
							?>
						</div>
						
						<?php }?>
					</div>
					<div class="col-xs-5 pull-right" style=" padding: 0; margin: 0;display: block; width: auto">
						<img  src="<?php echo $data2['path'];?>"  width="100" height="100" alt="alt avatar" />
					</div>
				</div>
				<div class="panel-body">
                     <?php
						echo $row['msg'];
					?>
                     <br>
                     <?php
                        if (!(empty($_COOKIE)) && $_COOKIE["role"] == 1)
                            echo 'button type="submit" name="del_button" class="btn btn-primary btn-xs">Delete</button>';
                        
                        ?>
				</div>
            </div>
			</hr>
         </form>
		 <div>
         <?php
            $c++;
			echo '</div>';
            }
            
            if ($c == 0) // если ни одной записи не встретилось
            echo "GuestBook is empty!<br>";
            
            
            ?>
         </br>
    <script src="http://code.jquery.com/jquery-latest.js"></script>
    <script src="js/bootstrap.min.js"></script>
  </body>
</html>