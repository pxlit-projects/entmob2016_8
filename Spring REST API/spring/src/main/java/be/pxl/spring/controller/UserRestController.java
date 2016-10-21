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
		// need to explicitly set Sessions to null or the Json serializer will load the Sessions despite lazy loading
		User u = us.findOne(id);
		u.setSessions(null);
		return u;
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
	
	@RequestMapping(method = RequestMethod.POST, value="werkgever/{id}/{pw}")
	public Boolean loginWerkgever(@PathVariable("id") int id, @PathVariable("pw") String pw){
		User user = us.findOne(id);
		if(user.getPassword().equals(pw) && user.getRole() == "admin")
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
}
