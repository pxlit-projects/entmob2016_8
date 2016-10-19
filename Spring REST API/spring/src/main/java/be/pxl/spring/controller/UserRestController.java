package be.pxl.spring.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
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
	
	@RequestMapping(method = RequestMethod.GET, value="{id}")
	public User getUserById(@PathVariable("id") int id){
		return us.findOne(id);
	}
	@RequestMapping(method= RequestMethod.GET)
	public String hello()
	{
		return "hello";
	}
	@RequestMapping(method = RequestMethod.GET, value="{name}")
	public List<User> getUsersByName(@PathVariable("name") String name){
		return us.findByName(name);
	}
	@RequestMapping(method = RequestMethod.GET, value="{department}")
	public List<User> getUsersByDepartment(@PathVariable("department") String department){
		return us.findByName(department);
	}
	
	@RequestMapping(method = RequestMethod.POST, value="{u}")
	public void updateUser(@PathVariable("u") User u){
		us.save(u);
	}
	
	@RequestMapping(method = RequestMethod.POST, value="{id}/{pw}")
	public Boolean login(@PathVariable("id") int id, @PathVariable("pw") String pw){
		User user = us.findOne(id);
		if(user.getPassword().equals(pw))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	
	
}
