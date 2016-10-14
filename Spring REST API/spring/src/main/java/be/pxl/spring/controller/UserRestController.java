package be.pxl.spring.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.spring.domain.User;
import be.pxl.spring.service.UserService;

@RestController
@RequestMapping(value="/user", produces="application/json")
public class UserRestController {

	
	@Autowired
	UserService us;
	
//	@RequestMapping(method = RequestMethod.GET)
//	public User getUserById(int id){
//		return us.findOne(id);
//	}
	@RequestMapping(method= RequestMethod.GET)
	public String hello()
	{
		return "hello";
	}
	@RequestMapping(method = RequestMethod.POST)
	public void updateUser(User u){
		us.save(u);
	}
	
	
}
