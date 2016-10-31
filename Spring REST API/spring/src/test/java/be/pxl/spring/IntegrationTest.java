package be.pxl.spring;


import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import be.pxl.spring.controller.UserRestController;
import be.pxl.spring.domain.User;

@RunWith(SpringJUnit4ClassRunner.class)
public class IntegrationTest {	
	

	@Test
	public void testCreateUser(){
		ConfigurableApplicationContext ctx = SpringApplication.run(
				AppConfig.class);
		User u = ctx.getBean(User.class);
		u.setFirstName("brecht");
		u.setDepartment("Integration");
		u.setLastName("morrhey");
		u.setPassword("test");
		u.setSalt("test");
		u.setRole("test");
		UserRestController urc = ctx.getBean(UserRestController.class);
		int newUserId = urc.updateUser(u);
		User u2 = urc.getUserById(newUserId).getBody();		
		Assert.assertNotNull(u2);		
	}
}
