<!DOCTYPE html>
<html>

<?php
	$page = "Administration Features";
	include ("./include/head.php");
?>
   <body>
      <?php
         $r = mysqli_query($link1, "SELECT * FROM users") or die('Error'); 
                   while ($row = mysqli_fetch_array($r)) 
                       {
         
         		   ?>
      <hr>
      <form name="myForm" action="administration/administration_buttons.php" method="post" enctype="multipart/form-data" >
         <table class="table">
            <thead>
               <tr>
                  <th>id</th>
                  <th>Name</th>
                  <th>Username</th>
                  <th>Password</th>
                  <th>Banned</th>
                  <th>Administration</th>
               </tr>
            </thead>
            <tbody>
               <tr>
                  <td> <input type="text" readonly name="id" id="inputName" value="<?php echo $row['ID'];   ?> "></td>
                  <td> <input type="text" name="name" id="inputName" value="<?php echo $row['name'];   ?> "></td>
                  <td><input type="text" name="nickname" id="inputLogin" value="<?php echo $row['nickname'];   ?> "></td>
                  <td><input type="text" name="password" id="inputInfo" value="<?php   ?> "></td>
                  <td>
                     <?php  
                        if ($row["ban"] == 0) {
                               echo '<button type="submit" name="lock_button" class="btn btn-default btn-sm">Lock</button>';
                           } else {
                               echo '<button type="submit" name="lock_button" class="btn btn-default btn-sm">Unlock</button>';
                           }
                        ?>
                  </td>
                  <td>
                     <?php 
                        if ($row["role"] == 0) {
                                              echo '<button type="submit" name="access_button" class="btn btn-default btn-sm">User. Make a Admin</button>';
                                          } else {
                                              echo '<button type="submit" name="access_button" class="btn btn-default btn-sm">Admin</button>';
                                          }
                        
                        ?>
                  </td>
               </tr>
            </tbody>
         </table>
         <table class="table">
            <thead>
               <tr>
                  <th>Email</th>
                  <th>Pic path</th>
                  <th>Information</th>
                  <th>Update</th>
                  <th>Delete</th>
               </tr>
            </thead>
            <tbody>
               <tr>
                  <td> <input type="text" name="email" id="inputEmail" value="<?php echo $row['email'];   ?> "></td>
                  <td> <input type="text" name="path" id="inputPath" value="<?php echo $row['path'];   ?> "></td>
                  <td><input type="text" name="information" id="inputInfo" value="<?php echo $row['information'];   ?> "></td>
                  <td> <button type="submit" name="Update_user" class="btn btn-warning btn-sm ">Update</button> </td>
                  <td><button type="submit" name="Delete_user" class="btn btn-danger btn-sm ">Delete</button> </td>
               </tr>
            </tbody>
         </table>
         </hr>
         </br>
      </form>
      <?php  
         }
         
         
         
         ?>
      <script src="http://code.jquery.com/jquery-latest.js"></script>
   </body>
</html>