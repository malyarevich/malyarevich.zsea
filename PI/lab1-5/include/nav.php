<div class="header">
	<ul class="nav nav-pills pull-right">
	   <li<?php if($page == "Home"){ echo ' class="active"';}?>><a href="./index.php">Home</a></li>
	   <li<?php if($page == "GuestBook"){ echo ' class="active"';}?>><a href="./guestbook.php">GuestBook</a></li>
	   <li<?php if($page == "Articles"){ echo ' class="active"';}?>><a href="./Content.php">Articles</a></li>
	   <?php      
	   if (empty($_COOKIE))
		  {
			echo "<li ";
			if($page == "Sign In"){ 
				echo ' class=\"active\"';
			}
			echo '><a href="./login.php">Sign In</a></li>';
		  }
		  else
		  {
			  if($_COOKIE["role"] == 1)
			  {
				echo "<li ";
				if($page == "Administration Block"){ 
					echo ' class=\"active\"';
				}
				echo '><a href="./administration_block.php">Administration Block</a></li>';
			  }
			echo "<li ";
			if($page == "Profile"){ 
				echo ' class=\"active\"';
			}
			echo '><a href="./profile.php">Profile</a></li>';
			
			echo "<li ";
			if($page == "Exit"){ 
				echo ' class=\"active\"';
			}
			echo '><a href="./exit.php">Exit</a></li>';
		  }
		  
		?>
	</ul>
	<h3 class="text-muted"><?php echo $page;?></h3>
 </div>
         <div class="jumbotron" <?php if ($page == "Registration") { echo "style=\"display: none;\"";} ?>>
            <h3 class="text-muted">
               <?php 
                  if(!(empty($_COOKIE))){
					echo "Hello ";
					echo $_COOKIE["nickname"]; 
                  if($_COOKIE["role"] == 1)
                  {
                  echo " You are admin.";
                  }
                  }
                  
                  		 ?>
            </h3>
            <h1>Bootstrap Company</h1>
            <p class="lead">Simple solutions. Variety of ideas and opinions. Quick problem solving and excellent implementation.
               Our developments help you deal with any challenge.
            </p>
            <?php if (empty($_COOKIE))
               {
               	echo '<p><a class="btn btn-lg btn-success" href="./registration.php" role="button">Sign up today</a></p>';
               } ?>
         </div>
 