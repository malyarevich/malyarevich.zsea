<html>
   
<?php
	$page = "GuestBook";
	include ("./include/head.php");
?>
   <body>
      <!-- проверка заполнения формы -->
      <script>
         function splash()
         {

         		
         	if (document.myForm.msg.value  =='')
         		{
         			alert ("Enter text!");
         			return false;	
         		}
         	
         	return true;   
         }
      </script>
      <div class="container">
         <?php 
		 include ("./include/nav.php");?>
         
             <?php include 'show_messages_from_gb.php'	   ?>
         <!-- форма отправки сообщения -->
         <form name="myForm" action="action_with_gb.php" method="post" onSubmit="return splash();">
            <input type="hidden" name="action" value="add">
            <?php
               if (!empty($_COOKIE))
               {
			   $query = mysqli_query($link1, "SELECT * FROM users WHERE ID = '".$_COOKIE["id"]."';");
                     
				$data = mysqli_fetch_assoc($query);
               
                if($data["ban"] != 1) {
                echo '<table border="0">
                           
                           	<tr>
                           		<td>
                           			<div class="form-group">
                             <label for="comment">Message:</label>
                             <textarea class="form-control" name="msg" rows="5" cols="150" id="comment"></textarea>
                           </div>
                           		</td>
                           	</tr>		
                           	<tr>
                           		
                           		<td>
                           			 <button type="submit" class="btn btn-primary btn-lg">Send</button>
                           		</td>
                           	</tr>
                           </table>';
               }
               else if($data["ban"] == 1)
               {
               echo "You are blocked. Contact your administrator";
               }
               }
			   else  
			   {
                echo "Sign up and leave a message.";
               }
               
               ?>
         </form>
         <div class="footer">
            <p>&copy; Company 2017</p>
         </div>
      </div>
   </body>
</html>