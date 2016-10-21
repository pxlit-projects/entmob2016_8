package be.pxl.spring;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import be.pxl.spring.service.UserService;

@RunWith(SpringJUnit4ClassRunner.class)
@DirtiesContext
public class UserServiceTest {
	
@Autowired
private UserService us;

@Test
public void saveUserTest(){
	
}

}
