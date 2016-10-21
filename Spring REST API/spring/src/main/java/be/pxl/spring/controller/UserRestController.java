package be.pxl.spring.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;


import be.pxl.spring.domain.User;
import be.pxl.spring.service.UserService;

@RestController
@RequestMapping(value="/user", produces="application/json")
public class UserRestController {
	//LazyLoading is enabled, use UserSessionRestController if you want to include the user sessions
	
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
	@RequestMapping(method = RequestMethod.GET, value="ByName/{name}")
	public List<User> getUsersByName(@PathVariable("name") String name){
		return us.findByName(name);
	}
	@RequestMapping(method = RequestMethod.GET, value="ByDepartment/{department}")
	public List<User> getUsersByDepartment(@PathVariable("department") String department){
		return us.findByName(department);
	}
	
	@RequestMapping(method = RequestMethod.POST)
	public int updateUser(@RequestBody User u){
		us.save(u);
		us.flush();
		return u.getUserId();
		
	}
	
	@RequestMapping(method = RequestMethod.DELETE)
	public void deleteUser(@RequestBody User u){
		us.delete(u);
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
