package be.pxl.spring;


import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import be.pxl.spring.controller.UserRestController;
import be.pxl.spring.domain.User;

@RunWith(SpringJUnit4ClassRunner.class)
@SpringBootTest
public class IntegrationTest {	
	@Autowired
	UserRestController urc;

	@Test
	public void testCreateUser(){		
		User u = new User();
		u.setFirstName("brecht");
		u.setDepartment("Integration");
		u.setLastName("morrhey");
		u.setPassword("test");
		u.setSalt("test");
		u.setRole("test");		
		int newUserId = urc.updateUser(u);
		User u2 = urc.getUserById(newUserId).getBody();		
		Assert.assertNotNull(u2);		
	}
}
